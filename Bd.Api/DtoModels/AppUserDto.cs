
using System.Collections.Generic;

namespace Bd.Api.DtoModels
{
    public class AppUserDto
    {

        public AppUserDto()
        {
            Orders = new List<OrderDto>();
        }
        public string AppUserId { get; set; }

        public string GenderId { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }

        public string FirstLineOfAddress { get; set; }

        public string SecondLineOfAddress { get; set; }

        public string Town { get; set; }

        public string Password { get; set; }

        public string ConfirmedPassword { get; set; }

        public string PostCode { get; set; }


        public GenderDto Gender { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public virtual List<OrderDto> Orders { get; set; }
    }
}
