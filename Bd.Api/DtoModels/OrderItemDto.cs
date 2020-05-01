using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.DtoModels
{
    public class OrderItemDto
    {
        public string OrderItemId { get; set; }

        public string OrderId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string ProductType { get; set; }

        public DateTime CreatedDate { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public double TotalQuantityPrice { get; set; }

        public OrderDto Order { get; set; }

        //public ProductDto Product { get; set; }

    }
}
