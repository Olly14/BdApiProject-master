using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.DtoModels
{
    public class CountryDto
    {
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        //Navigation property
        public IEnumerable<AppUserDto> AppUsers { get; set; }
    }
}
