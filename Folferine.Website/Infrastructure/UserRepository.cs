using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Folferine.Website.Domain;
using Folferine.Website.Domain.Repositories;

namespace Folferine.Website.Infrastructure
{
    public class UserRepository : Repository<Player, string>, IUserRepository
    {
        private readonly FolferineContext context;

        public UserRepository(FolferineContext context) : base(context)
        {
            this.context = context;
        }

        public Player GetByUserName(string userName)
        {
            return context.Set<Player>().Single(x => x.UserName == userName);
        }
    }
}