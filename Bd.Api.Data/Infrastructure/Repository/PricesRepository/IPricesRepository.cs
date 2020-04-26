

using Bank.Api.Data.Infrastructure.Repository;
using Bd.Api.Domain;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Repository.PricesRepository
{
    public interface IPricesRepository : IRepository<Prices>
    {
        Task<Prices> FindByIdAndTypeAsync(string id, string type);

        Task<Prices> FindByTypeAsync(string type);

    }
}
