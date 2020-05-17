using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Web.Api.DtoModels
{
    public class UserLoginDto
    {
        //public UserLogin()
        //{
        //    SubjectId = Convert.ToString(UserLoginInt);
        //}
        public UserLoginDto(string loginProvider, string providerKey)
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(50)]
        //public int UserLoginInt { get; set; }


        public Guid Id { get; set; }


        public string SubjectId { get; set; }


        public string LoginProvider { get; set; }


        public string ProviderKey { get; set; }

        //Navigation property
        public UserDto User { get; set; }
    }
}
