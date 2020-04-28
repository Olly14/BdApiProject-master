using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.OrderItemRepository;
using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence.OrderItemsRepo
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(BdContext bdContext) : base(bdContext)
        {

        }

        public async Task<IEnumerable<OrderItem>> FindOrderItemsByOrderIdAsync(string id)
        {
            return await Task.Run(() => BdContext.OrderItems.Where(oi => oi.OrderId == id));
        }
    }
}
