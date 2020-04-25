using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.DtoModels
{
    public class ProductDto
    {
        public ProductDto()
        {
            OrderItems = new List<OrderItemDto>();
        }
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public virtual List<OrderItemDto> OrderItems { get; set; }

    }
}
