using System.Collections.Generic;

namespace Folferine.Domain
{
    public class Scorecard
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public List<Round> Rounds { get; set; }

        public Game Game { get; set; }
    }
}