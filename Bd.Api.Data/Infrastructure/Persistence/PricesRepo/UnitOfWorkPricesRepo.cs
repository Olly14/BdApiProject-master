using Bank.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data.Infrastructure.Persistence.PricesRepo
{
    public class UnitOfWorkPricesRepo : UnitOfWork<Prices>, IUnitOfWork<Prices>
    {
        public UnitOfWorkPricesRepo(BdContext context) : base(context)
        {

        }
    }
}
