using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.OrderRepository;
using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence.OrdersRepo
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(BdContext bdContext) : base(bdContext)
        {

        }

        public async Task<IEnumerable<Order>> FindOrdersWithOrderItemsAsync()
        {
            return await Task.Run(() => BdContext.Orders.Include(o => o.OrderItems).OrderBy(o => o.CreatedDate));
        }
    }
}
