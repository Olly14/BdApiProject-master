using Bank.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data.Infrastructure.Persistence.ProductsRepo
{
    public class UnitOfWorkProductRepo : UnitOfWork<Product>, IUnitOfWork<Product>
    {
        public UnitOfWorkProductRepo(BdContext bdContext) : base(bdContext)
        {

        }
    }
}
