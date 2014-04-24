using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using Folferine.Website.Domain;
using Folferine.Website.Domain.Repositories;

namespace Folferine.Website.Infrastructure
{
    public class GameRepository : Repository<Game, int>, IGameRepository
    {
        private readonly FolferineContext context;

        public GameRepository(FolferineContext context) : base(context)
        {
            this.context = context;
        }

        public List<Game> GetPlayerGames(string userName)
        {
            return context.Set<Game>()
                .Where(x => x.Scorecards.Any(y => y.Player.UserName == userName))
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }
        
        public List<Game> GetGamesCreatedAt(DateTime createdDate)
        {
            return context.Set<Game>()
                .Where(x => SqlFunctions.DateDiff("day", x.CreatedDate, createdDate) == 0)
                .OrderByDescending(x => x.CreatedDate)
                .ToList();
        }
    }
}