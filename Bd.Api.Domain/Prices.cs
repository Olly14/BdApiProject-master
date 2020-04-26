using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace Bd.Api.Domain
{
    
    public class Prices
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PricesId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }


    }
}
