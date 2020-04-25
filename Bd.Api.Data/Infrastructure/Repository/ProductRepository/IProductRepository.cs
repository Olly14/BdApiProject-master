using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Repository.ProductRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> FindPoductsWithOrderItemsAsync();
    }
}
