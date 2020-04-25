using Bank.Data.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence
{
    public class UnitOfWork<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        private DbSet<TEntity> _dbSet;

        public BdContext BdContext => DbContext as BdContext;

        protected UnitOfWork(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();
        }

        public async Task<TEntity> UpdateAsync(CancellationToken cancellationToken,TEntity entity)
        {
            var newAttachedAccount = _dbSet.Attach(entity);
            newAttachedAccount.State = EntityState.Modified;
            await this.CommitAsync(cancellationToken);
            return entity;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await DbContext.SaveChangesAsync();
        }
    }
}
