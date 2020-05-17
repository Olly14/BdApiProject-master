using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bd.Api.Domain
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }

        //Navigation property
        public IEnumerable<AppUser> AppUsers { get; set; }
    }
}
