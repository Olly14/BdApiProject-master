using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.DtoModels
{
    public class OrderProductDto
    {
        public string OrderId { get; set; }

        public OrderDto Order { get; set; }

        public string ProductId { get; set; }

        public ProductDto Product { get; set; }
    }
}
