using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.OrderHistoryRepository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence.OrderHistoryRepo
{
    public class OrderHistoryRepository : Repository<OrderHistory>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(BdContext context) : base(context)
        {
            
        }

        public async Task<IEnumerable<OrderHistory>> FindOrderHistoriesByAppUserIdAsync(string id)
        {
            return await Task.Run(() => BdContext.OrderHistories.Where(oh => oh.AppUserId == id));
        }
    }
}
