using Bd.Api.Domain;
using System.Threading.Tasks;




namespace Bd.Api.Data.Infrastructure.Repository.IDropDownListsRepository
{
    public interface IGenderRepository : IDropDownListRepository<Gender>
    {
        Task<Gender> FindGenderTypeByGenderTypeId(string genderId);
    }
}
