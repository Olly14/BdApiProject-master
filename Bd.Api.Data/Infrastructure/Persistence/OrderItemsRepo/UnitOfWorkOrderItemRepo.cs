using Bank.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data.Infrastructure.Persistence.OrderItemsRepo
{
    public class UnitOfWorkOrderItemRepo : UnitOfWork<OrderItem>, IUnitOfWork<OrderItem>
    {
        public UnitOfWorkOrderItemRepo(BdContext context) : base(context)
        {

        }
    }
}
