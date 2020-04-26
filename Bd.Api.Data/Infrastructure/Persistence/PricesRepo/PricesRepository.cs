

using Bank.Api.Data.Infrastructure.Persistence;
using Bd.Api.Data.Infrastructure.Repository.PricesRepository;
using Bd.Api.Domain;

namespace Bd.Api.Data.Infrastructure.Persistence.PricesRepo
{
    public class PricesRepository : Repository<Prices>, IPricesRepository
    {
        public PricesRepository(BdContext context) : base(context)
        {

        }
    }
}
