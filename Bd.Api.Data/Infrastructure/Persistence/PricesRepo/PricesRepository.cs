

using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.PricesRepository;
using Bd.Api.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.Data.Infrastructure.Persistence.PricesRepo
{
    public class PricesRepository : Repository<Prices>, IPricesRepository
    {
        public PricesRepository(BdContext context) : base(context)
        {

        }

        public async Task<Prices> FindByIdAndTypeAsync(string id, string type)
        {
            return await Task.Run(() => {

                return BdContext.Prices.FirstOrDefault(p => p.PricesId == id && p.Type == type);
            });
        }

        public async Task<Prices> FindByTypeAsync(string type)
        {
            return await Task.Run(() => {

                return BdContext.Prices.FirstOrDefault(p => p.Type == type);
            });
        }
    }
}
