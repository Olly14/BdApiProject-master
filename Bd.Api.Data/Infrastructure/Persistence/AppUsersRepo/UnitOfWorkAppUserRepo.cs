

using Bank.Data.Infrastructure.Repository;
using Bd.Api.Data;
using Bd.Api.Data.Infrastructure.Persistence;
using Bd.Api.Domain;

namespace Bd.Api.Data.Infrastructure.Persistence
{
    public class UnitOfWorkAppUserRepo : UnitOfWork<AppUser>, IUnitOfWork<AppUser>
    {
        public UnitOfWorkAppUserRepo(BdContext bdContext) : base(bdContext)
        {

        }
    }
}
