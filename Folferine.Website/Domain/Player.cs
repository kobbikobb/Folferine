using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Folferine.Website.Domain
{
    public class Player : IdentityUser
    {
        public virtual List<Scorecard> Scorecards { get; set; }

        public Player()
        {
            
        }
    }
}