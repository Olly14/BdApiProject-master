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
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        public Gender Gender { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
