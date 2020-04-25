using Bd.Api.Data;
using Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository;
using Bd.Api.Domain;
using System.Linq;
using System.Threading.Tasks;



namespace Bd.Api.Data.Infrastructure.Persistence.DropDownListsRepository
{
    public class GenderRepository : DropDownListRepository<Gender>, IGenderRepository
    {
        public GenderRepository(BdContext bdContext) : base(bdContext)
        {
            
        }

        public async Task<Gender> FindGenderTypeByGenderTypeId(string genderId)
        {
            return await Task.Run(() => BdContext.Genders
                .Where(g => g.GenderId == genderId)
                .ToList()
                .FirstOrDefault());

        }

    }
}
