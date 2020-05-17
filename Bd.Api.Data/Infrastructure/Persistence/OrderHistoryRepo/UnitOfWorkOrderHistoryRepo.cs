using Bank.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data.Infrastructure.Persistence.OrderHistoryRepo
{
    public class UnitOfWorkOrderHistoryRepo : UnitOfWork<OrderHistory>,  IUnitOfWork<OrderHistory>
    {
        public UnitOfWorkOrderHistoryRepo(BdContext context) : base(context)
        {

        }
    }
}
