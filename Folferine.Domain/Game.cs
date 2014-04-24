using System;
using System.Collections.Generic;

namespace Folferine.Domain
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }

        public Course Course { get; set; }
        public List<Scorecard> Scorecards { get; set; } 
    }
}