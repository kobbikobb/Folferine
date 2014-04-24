using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using Folferine.Website.Domain;
using Folferine.Website.Domain.Repositories;

namespace Folferine.Website.Infrastructure
{
    public abstract class Repository<TEntity,TKey> : IRepository<TEntity, TKey> 
        where TEntity : class
    {
        private readonly FolferineContext context;

        protected Repository(FolferineContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            this.context = context;
        }

        public TEntity Find(TKey id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public TEntity Get(TKey id)
        {
            var entity = context.Set<TEntity>().Find(id);
            
            if(entity == null)
                throw new ObjectNotFoundException(
                    string.Format("Could not find object of type {0}, with id {1}.", 
                    typeof(TEntity).Name, id));

            return entity;
        }


        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Create(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}