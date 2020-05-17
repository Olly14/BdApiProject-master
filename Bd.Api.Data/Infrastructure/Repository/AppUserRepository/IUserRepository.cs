using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System.Threading.Tasks;




namespace Bd.Api.Data.Infrastructure.Repository.AppUserRepository
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindUserByUserNameAsync(string username);
    }
}
