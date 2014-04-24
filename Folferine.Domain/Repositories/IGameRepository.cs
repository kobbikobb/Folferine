using System.Collections;
using System.Collections.Generic;

namespace Folferine.Domain.Repositories
{
    public interface IGameRepository
    {
        Game Find(int id);
        List<Game> GetAll();

        void Create(Game game);
        void Update(Game game);
        void Delete(Game game);

        void Save();
    }
}