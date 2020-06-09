using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.Domain
{
    [Table("UserClaims")]
    public class UserClaim
    {
        public UserClaim()
        {
        }
        public UserClaim(string claimType, string claimValue)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
        }
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(50)]
        //public int UserClaimIdInt { get; set; }

        [Key]
        [MaxLength(50)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }


        //Navigation property
        //[Required]
        //[MaxLength(50)]
        public string SubjectId { get; set; }

        [Required]
        [MaxLength(250)]
        public string ClaimType { get; set; }

        [Required]
        [MaxLength(250)]
        public string ClaimValue { get; set; }

        //Navigation property
        public User User { get; set; }



    }
}
