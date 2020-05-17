using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.OrderItemRepository;
using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence.OrderItemsRepo
{
    public class OrderItemHistoryRepository : Repository<OrderItemHistory>, IOrderItemHistoryRepository
    {
        public OrderItemHistoryRepository(BdContext bdContext) : base(bdContext)
        {

        }

        public async Task<IEnumerable<OrderItemHistory>> FindOrderItemsByOrderIdAsync(string id)
        {
            return await Task.Run(() => BdContext.OrderItemHistories.Where(oi => oi.OrderHistoryId == id));
        }

    }
}
