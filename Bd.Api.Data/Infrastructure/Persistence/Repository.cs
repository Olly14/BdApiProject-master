using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Data;
using Microsoft.EntityFrameworkCore;



namespace Bank.Api.Data.Infrastructure.Persistence
{
   public abstract class Repository<TEntity> :IRepository<TEntity> where TEntity : class
   {
       protected readonly DbContext DbContext;

       private DbSet<TEntity> _dbSet;

       public BdContext BdContext => DbContext as BdContext;

       protected Repository(DbContext dbContext)
       {
           DbContext = dbContext;
           _dbSet = DbContext.Set<TEntity>();
       }

        public async Task AddAsync(TEntity entity)
        {
            await Task.Run(() => _dbSet.Add(entity));
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _dbSet.AddRange(entities));
        }

        public async Task<TEntity> FindAsync(string id)
        {
            return await Task.Run(() => _dbSet.Find(id));
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            var result = await Task.Run(() => _dbSet.ToList());

            return result;
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _dbSet.Where(predicate));
        }

        public async Task RemoveAsync(TEntity entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));
        }

        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            await Task.Run(() => _dbSet.RemoveRange(entities));
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() => _dbSet.SingleOrDefault(predicate));
        }

   }
}
