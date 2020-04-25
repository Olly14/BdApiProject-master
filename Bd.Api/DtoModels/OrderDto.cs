using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd.Api.DtoModels
{
    public class OrderDto
    {

        public OrderDto()
        {
            OrderItems = new List<OrderItemDto>();
        }
        public string OrderId { get; set; }

        public string AppUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        public double TotalPrice { get; set; }

        public virtual List<OrderItemDto> OrderItems { get; set; }
        public AppUserDto AppUser { get; set; }

    }
}
