using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Folferine.Website.Models
{
    public class ScorecardViewModel
    {
        public string PlayerUserName { get; set; }
        public List<RoundViewModel> Rounds { get; set; }

        public int SumScore
        {
            get { return Rounds.Sum(x => x.Score); }
        }
    }
}