using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Repository.OrderItemRepository
{
    public interface IOrderItemHistoryRepository : IRepository<OrderItemHistory>
    {
        Task<IEnumerable<OrderItemHistory>> FindOrderItemsByOrderIdAsync(string id);
    }
}
