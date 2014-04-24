using System.Data.Entity;
using Folferine.Website.Domain;
using Folferine.Website.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Folferine.Website.Infrastructure
{
    public class FolferineContext : IdentityDbContext<Player>
    {
        public FolferineContext() : base("FolferineContext")
        {

        }

        public FolferineContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }
    }
}
