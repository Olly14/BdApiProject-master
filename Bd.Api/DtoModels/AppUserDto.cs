
using Bd.Web.Api.DtoModels;
using System;
using System.Collections.Generic;

namespace Bd.Api.DtoModels
{
    public class AppUserDto
    {

        public AppUserDto()
        {
            Orders = new List<OrderDto>();
            OrderHistories = new List<OrderHistoryDto>();
        }
        public string AppUserId { get; set; }

        public string SubjectId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string GenderId { get; set; }

        public string CountryId { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }

        public string FirstLineOfAddress { get; set; }

        public string SecondLineOfAddress { get; set; }

        public string Town { get; set; }

        public string PostCode { get; set; }

        public GenderDto Gender { get; set; }

        public CountryDto Country { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public bool IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifierAppUserId { get; set; }

        public virtual List<OrderDto> Orders { get; set; }

        public virtual List<OrderHistoryDto> OrderHistories { get; set; }

        public int OrderHistoryCount { get; set; }

        public virtual ICollection<string> Roles { get; set; }

        public virtual ICollection<string> Claims { get; set; }
    }
}
