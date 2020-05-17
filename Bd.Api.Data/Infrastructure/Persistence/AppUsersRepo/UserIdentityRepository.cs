using Bd.Api.Data.Infrastructure.Repository.AppUserRepository;
using Bd.Api.Domain;
using System.Linq;
using System.Threading.Tasks;




namespace Bd.Api.Data.Infrastructure.Persistence.AppUsersRepo
{
    public class UserIdentityRepository : UserRepository<User>, IUserRepository
    {
        public UserIdentityRepository(UserIdentityDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<User> FindUserByUserNameAsync(string username)
        {
            return await Task.Run(() => UserIdentityDbContext.Users.Where(u => u.Username == username).FirstOrDefault());
        }
    }
}
