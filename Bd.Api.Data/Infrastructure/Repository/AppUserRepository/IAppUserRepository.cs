using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Repository.AppUserRepositiry
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<IEnumerable<AppUser>> FindAppUsersWithOrderAsync();

        Task<AppUser> FindAppUserWithOrderAsync(string id);
    }
}
