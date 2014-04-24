using System.Collections.Generic;

namespace Folferine.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }

        public List<Scorecard> Scorecards { get; set; } 
    }
}