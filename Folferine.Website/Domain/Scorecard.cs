using System;
using System.Collections.Generic;
using System.Linq;

namespace Folferine.Website.Domain
{
    public class Scorecard
    {
        public int Id { get; set; }

        public virtual Player Player { get; set; }
        public virtual List<Round> Rounds { get; set; }
        public virtual Game Game { get; set; }

        public Scorecard()
        {
            Rounds = new List<Round>();
        }

        public Scorecard(Game game, Player player) : this()
        {
            Game = game;
            Player = player;
        }

        public void CreateRounds(int holeCount)
        {
            if(Rounds.Any())
                throw new InvalidOperationException("Rounds have already been set.");

            for (int i = 1; i <= holeCount; i++)
            {
                Rounds.Add(new Round(i, 3, this));
            }
        }

        public Round GetRound(int number)
        {
            return Rounds.Single(x => x.Number == number);
        }

        public string GetUserName()
        {
            return Player.UserName;
        }
    }
}