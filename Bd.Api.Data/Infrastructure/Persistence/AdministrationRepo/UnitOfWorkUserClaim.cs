using Bank.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Data.Infrastructure.Persistence.AdministrationRepo
{
    public class UnitOfWorkUserClaim : UnitOfWorkUser<UserClaim>, IUnitOfWork<UserClaim>
    {
        public UnitOfWorkUserClaim(UserIdentityDbContext dbContext) : base(dbContext)
        {

        }
    }
}
