using Bank.Data.Infrastructure.Repository;
using Bd.Api.Domain;




namespace Bd.Api.Data.Infrastructure.Persistence.AppUsersRepo
{
    public class UnitOfWorkUserRepo : UnitOfWorkUser<User>, IUnitOfWork<User>
    {
        public UnitOfWorkUserRepo(UserIdentityDbContext dbContext) : base(dbContext)
        {

        }
    }
}
