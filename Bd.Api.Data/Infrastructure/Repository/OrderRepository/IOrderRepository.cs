using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Repository.OrderRepository
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<Order>> FindOrdersWithOrderItemsAsync();
    }
}
