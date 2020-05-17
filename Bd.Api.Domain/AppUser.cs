using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bd.Api.Domain
{
    [Table("AppUsers")]
    public class AppUser
    {
        public AppUser()
        {
            Orders = new List<Order>();
            OrderHistories = new List<OrderHistory>();

        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AppUserId { get; set; }

        public string SubjectId { get; set; }

        public string GenderId { get; set; }

        public string CountryId { get; set; }

        public string UserName { get; set; }

        public string MobileNumber { get; set; }

        public string FirstLineOfAddress { get; set; }

        public string SecondLineOfAddress { get; set; }

        public string Town { get; set; }

        public string PostCode { get; set; }

        public Gender Gender { get; set; }

        public Country Country { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public bool IsBlocked { get; set; }

        public virtual List<Order> Orders { get; set; }

        public virtual List<OrderHistory> OrderHistories { get; set; }

        public int OrderHistoryCount { get; set; }
        [NotMapped]
        public virtual ICollection<string> Roles { get; set; }
        [NotMapped]
        public virtual ICollection<string> Claims { get; set; }
    }
}
