using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ArmyTechTask.Repositories.Interfaces;

namespace ArmyTechTask.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        protected readonly DbSet<TEntity> entities;

        public Repository(DbContext context)
        {
            Context = context;
            entities = Context.Set<TEntity>();
        }

        public async Task<TEntity> Get(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            return await Task.FromResult(entities.Add(entity));
        }

        public async Task<TEntity> Edit(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public async Task<bool> Remove(int id)
        {
            TEntity entity = entities.Find(id);
            if (entity != null)
            {
                Context.Entry(entity).State = EntityState.Deleted;

                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

    }
}