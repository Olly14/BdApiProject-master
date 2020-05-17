using Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bd.Api.Domain;


namespace Bd.Api.Data.Infrastructure.Persistence.DropDownListsRepo
{
    public class CountryRepository : DropDownListRepository<Country>, ICountryRepository
    {
        public CountryRepository(BdContext dbContext):base(dbContext)
        {
                
        }
    }
}
