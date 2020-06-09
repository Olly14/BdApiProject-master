using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.Domain
{
    [Table("UserLogins")]
    public class UserLogin
    {

        //public UserLogin()
        //{
        //    SubjectId = Convert.ToString(UserLoginInt);
        //}
        public UserLogin(string loginProvider, string providerKey)
        {
            LoginProvider = loginProvider;
            ProviderKey = providerKey;
        }

        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[MaxLength(50)]
        //public int UserLoginInt { get; set; }

        [Key]
        [MaxLength(50)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        //[Required]
        //[MaxLength(50)]
        public string SubjectId { get; set; }

        [Required]
        [MaxLength(250)]
        public string LoginProvider { get; set; }

        [Required]
        [MaxLength(250)]
        public string ProviderKey { get; set; }

        //Navigation property
        public User User { get; set; }
    }
}
