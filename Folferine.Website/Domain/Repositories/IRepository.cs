using System.Collections.Generic;

namespace Folferine.Website.Domain.Repositories
{
    public interface IRepository<TEntity, TKey>
    {
        TEntity Find(TKey id);
        TEntity Get(TKey id);
        List<TEntity> GetAll();

        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        void Save(); 
    }
}