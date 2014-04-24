using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folferine.Website.Models
{
    public class GameRoundViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public List<PlayerScoreViewModel> PlayerScores { get; set; }

        public GameRoundViewModel()
        {
            PlayerScores = new List<PlayerScoreViewModel>();
        }

        public void AddPlayer(string userName, int score)
        {
            var playerScore = new PlayerScoreViewModel()
            {
                UserName = userName,
                Score = score
            };
            PlayerScores.Add(playerScore);
        }
    }
}