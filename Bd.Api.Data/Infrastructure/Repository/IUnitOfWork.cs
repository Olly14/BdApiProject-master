using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bank.Data.Infrastructure.Repository
{
    public interface IUnitOfWork<TEntity> where TEntity : class
    {
        Task<TEntity> UpdateAsync(CancellationToken cancellationToken, TEntity entity);

        Task CommitAsync(CancellationToken cancellationToken);
    }
}
