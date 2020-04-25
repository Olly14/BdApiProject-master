using System.Collections.Generic;
using System.Threading.Tasks;
using Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Microsoft.EntityFrameworkCore;

namespace Bd.Api.Data.Infrastructure.Persistence
{
    public abstract class DropDownListRepository<TEntity> : IDropDownListRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _dbContext;

        private  DbSet<TEntity> _dbSet;

        public BdContext BdContext => _dbContext as BdContext;

        public DropDownListRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return await Task.Run(() => _dbSet);
        }


        public async Task<TEntity> FindAsync(string id)
        {
            return await Task.Run(() => _dbSet.Find(id));
        }
    }
}
