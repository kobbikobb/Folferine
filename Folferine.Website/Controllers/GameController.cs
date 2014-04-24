using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Routing;
using AutoMapper;
using Folferine.Website.Domain;
using Folferine.Website.Domain.Repositories;
using Folferine.Website.Models;
using Microsoft.Ajax.Utilities;

namespace Folferine.Website.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        private readonly IGameRepository gameRepository;
        private readonly ICourseRepository courseRepository;
        private readonly IUserRepository userRepository;

        public GameController(
            IGameRepository gameRepository, 
            ICourseRepository courseRepository, 
            IUserRepository userRepository)
        {
            this.gameRepository = gameRepository;
            this.courseRepository = courseRepository;
            this.userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var playerGames = gameRepository.GetPlayerGames(User.Identity.Name);
            return View(Mapper.Map<List<Game>, List<GameViewModel>>(playerGames));
        }

        public ActionResult Details(int id)
        {
            var game = gameRepository.Find(id);
            if (game == null || !game.HasPlayer(User.Identity.Name))
                return HttpNotFound();

            return View("Details", Mapper.Map<Game, GameDetailsViewModel>(game));
        }

        public ActionResult Create()
        {
            var viewModel = new CreateGameViewModel
            {
                Courses = courseRepository.GetAll(),
                OtherUsers = userRepository.GetAll()
                .Where(x => x.UserName != User.Identity.Name).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGameViewModel viewModel)
        {
            var game = new Game
            {
                CreatedDate = DateTime.Now,
                Course = courseRepository.Get(viewModel.SelectedCourseId)
            };
            game.AddPlayer(userRepository.GetByUserName(User.Identity.Name));
            foreach (var selectedOtherUser in viewModel.SelectedOtherUserNames)
            {
                game.AddPlayer(userRepository.GetByUserName(selectedOtherUser));
            }
            game.CreateRounds();

            if (ModelState.IsValid)
            {
                gameRepository.Create(game);
                gameRepository.Save();

                return RedirectToAction("Continue", new { id = game.Id });
            }

            return View(viewModel);
        }

        public ActionResult Continue(int id)
        {
            var game = gameRepository.Find(id);
            if (game == null || !game.HasPlayer(User.Identity.Name))
                return HttpNotFound();

            return RedirectToAction("GameRound", new {id, number = game.GetNextRoundNumber()});
        }

        public ActionResult GameRound(int id, int number)
        {
            var game = gameRepository.Find(id);
            if (game == null || !game.HasPlayer(User.Identity.Name))
                return HttpNotFound();

            return View(GetGameRoundViewModel(game, number));
        }

        private static GameRoundViewModel GetGameRoundViewModel(Game game, int number)
        {
            var gameRoundViewModel = new GameRoundViewModel()
            {
                Id = game.Id,
                Number = number
            };

            foreach (var scorecard in game.Scorecards)
            {
                var round = scorecard.GetRound(number);
                gameRoundViewModel.AddPlayer(scorecard.GetUserName(), round.Score);
            }
            return gameRoundViewModel;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GameRound(GameRoundViewModel viewModel)
        {
            var game = gameRepository.Find(viewModel.Id);
            if (game == null || !game.HasPlayer(User.Identity.Name))
                return HttpNotFound();

            if (ModelState.IsValid)
            {
                foreach (var playerScore in viewModel.PlayerScores)
                {
                    game.SetRoundScore(viewModel.Number, playerScore.UserName, playerScore.Score);
                }

                gameRepository.Update(game);
                gameRepository.Save();

                if (viewModel.Number < game.GetHoleCount())
                    return RedirectToAction("GameRound", new {id = viewModel.Id, number = viewModel.Number + 1});
                return RedirectToAction("Details", new { id = viewModel.Id });
            }

            return View(viewModel);
        }

        public ActionResult Delete(int id)
        {
            Game game = gameRepository.Find(id);
            if (game == null || !game.HasPlayer(User.Identity.Name))
                return HttpNotFound();

            return View(Mapper.Map<Game, GameDetailsViewModel>(game));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var game = gameRepository.Find(id);
            if (game == null || !game.HasPlayer(User.Identity.Name))
                return HttpNotFound();

            gameRepository.Delete(game);
            gameRepository.Save();

            return RedirectToAction("Index");
        }
    }
}
