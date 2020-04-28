using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.OrderRepository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data.Infrastructure.Persistence.OrdersRepo
{
    public class OrderProductRepository : Repository<OrderProduct>, IOrderProductRepository
    {
        public OrderProductRepository(BdContext bdContext) : base(bdContext)
        {

        }
    }
}
