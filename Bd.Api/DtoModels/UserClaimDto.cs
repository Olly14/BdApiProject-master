using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.Api.DtoModels
{
    public class UserClaimDto
    {

        public UserClaimDto()
        {
        }
        public UserClaimDto(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(50)]
        //public int UserClaimIdInt { get; set; }

        public Guid Id { get; set; }



        public string SubjectId { get; set; }


        public string ClaimType { get; set; }


        public string ClaimValue { get; set; }

        //Navigation property
        public UserDto User { get; set; }
    }
}
