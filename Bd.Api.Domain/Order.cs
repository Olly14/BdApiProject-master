using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bd.Api.Domain
{
    public class Order
    {
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderId { get; set; }

        public string AppUserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        public double TotalPrice { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; }
        public AppUser AppUser { get; set; }
    }
}
