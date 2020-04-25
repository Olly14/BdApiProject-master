using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public interface IDropDownListRepository <TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> FindAllAsync();

        Task<TEntity> FindAsync(string id);

    }
}