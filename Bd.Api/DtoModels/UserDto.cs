using Bd.Api.DtoModels;
using System.Collections.Generic;



namespace Bd.Web.Api.DtoModels
{
    public class UserDto
    {
        public string SubjectId { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsBlocked { get; set; }

        public ICollection<UserClaimDto> Claims { get; set; }
        public ICollection<UserLoginDto> Logins { get; set; }
        public string Email { get; set; }

        public AppUserDto AppUser { get; set; }
    }
}
