using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.AppUserRepositiry;
using Bd.Api.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence
{
    public class AppUserRepository : Repository<AppUser> , IAppUserRepository
    {
        public AppUserRepository(BdContext bdContext) : base(bdContext)
        {

        }

        public async Task<IEnumerable<AppUser>> FindAppUsersWithOrderAsync()
        {
            return await Task.Run(() => BdContext.AppUsers.Include(au => au.Orders).OrderBy(au => au.UserName).ToListAsync());
        }

        public async Task<AppUser> FindAppUserWithOrderAsync(string id)
        {
            return await Task.Run(() => BdContext.AppUsers.Include(au => au.Orders).Where(au=>au.AppUserId == id).FirstOrDefaultAsync());
        }
    }
}
