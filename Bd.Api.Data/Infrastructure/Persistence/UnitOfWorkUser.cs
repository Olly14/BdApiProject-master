using Bank.Data.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence
{
    public class UnitOfWorkUser<TEntity> : IUnitOfWork<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        protected static TEntity _tEntity = default;

        private DbSet<TEntity> _dbSet;

        public UserIdentityDbContext BankDbContext => DbContext as UserIdentityDbContext;

        protected UnitOfWorkUser(DbContext dbContext)
        {
            DbContext = dbContext;
            _dbSet = DbContext.Set<TEntity>();

        }

        public async Task<TEntity> UpdateAsync(CancellationToken cancellationToken, TEntity entity)
        {
            var newAttachedAccount = _dbSet.Attach(entity);
            newAttachedAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await this.CommitAsync(cancellationToken);
            
            return entity;
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await DbContext.SaveChangesAsync();

        }
    }
}
