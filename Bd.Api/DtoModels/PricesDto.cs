using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.DtoModels
{
    public class PricesDto
    {
        public string PricesId { get; set; }
        public string Type { get; set; }
        public double Price { get; set; }
    }
}
