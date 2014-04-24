using System;
using System.Collections.Generic;

namespace Folferine.Website.Domain.Repositories
{
    public interface IGameRepository : IRepository<Game, int>
    {
        List<Game> GetPlayerGames(string userName);
        List<Game> GetGamesCreatedAt(DateTime createdDate);
    }
}