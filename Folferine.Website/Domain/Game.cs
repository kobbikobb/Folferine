using System;
using System.Collections.Generic;
using System.Linq;

namespace Folferine.Website.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual List<Scorecard> Scorecards { get; set; }

        public Game()
        {
            Scorecards = new List<Scorecard>();
        }

        public void AddPlayer(Player player)
        {
            Scorecards.Add(new Scorecard(this, player));
        }

        public void CreateRounds()
        {
            foreach (var scorecard in Scorecards)
            {
                scorecard.CreateRounds(Course.HoleCount);
            }
        }

        public void SetRoundScore(int number, string userName, int score)
        {
            Scorecards.Single(x => x.GetUserName() == userName)
                .GetRound(number)
                .Score = score;
        }

        public int GetLastRoundNumber()
        {
            var lastRoundWithScore = Scorecards.SelectMany(x => x.Rounds)
                .Where(x => x.Score != 0)
                .OrderByDescending(x => x.Number)
                .FirstOrDefault();

            return lastRoundWithScore == null ? 1 : lastRoundWithScore.Number;
        }

        public int GetNextRoundNumber()
        {
            var firstRoundWithoutScore = Scorecards.SelectMany(x => x.Rounds)
                .Where(x => x.Score == 0)
                .OrderBy(x => x.Number)
                .FirstOrDefault();

            if (firstRoundWithoutScore == null)
                return Course.HoleCount;

            return firstRoundWithoutScore.Number;
        }

        public int GetHoleCount()
        {
            return Course.HoleCount;
        }

        public bool HasPlayer(string userName)
        {
            return Scorecards.Any(x => x.GetUserName() == userName);
        }
    }
}