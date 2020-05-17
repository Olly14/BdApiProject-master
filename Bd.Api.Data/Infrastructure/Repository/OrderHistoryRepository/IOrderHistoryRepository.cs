using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Repository.OrderHistoryRepository
{
    public interface IOrderHistoryRepository : IRepository<OrderHistory>
    {
        Task<IEnumerable<OrderHistory>> FindOrderHistoriesByAppUserIdAsync(string id);
    }
}
