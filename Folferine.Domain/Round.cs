using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Folferine.Domain
{
    public class Round
    {
        public int Id { get; set; }
        public int Score { get; set; }
        public int Par { get; set; }

        public Scorecard Scorecard { get; set; }
    }
}
