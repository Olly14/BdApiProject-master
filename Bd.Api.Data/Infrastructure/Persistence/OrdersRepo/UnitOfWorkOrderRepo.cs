using Bank.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data.Infrastructure.Persistence.OrdersRepo
{
    public class UnitOfWorkOrderRepo : UnitOfWork<Order>, IUnitOfWork<Order>
    {
        public UnitOfWorkOrderRepo(BdContext context) : base(context)
        {

        }
    }
}
