using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bd.Api.Domain
{
    [Table("OrderHistories")]
    public class OrderHistory
    {
        
        public OrderHistory()
        {
            OrderItems = new List<OrderItemHistory>();
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderHistoryId { get; set; }

        public string AppUserId { get; set; }

        public string ProductIdDetail { get; set; }

        public Order Order { get; set; }

        public AppUser AppUser { get; set; }

        public virtual List<OrderItemHistory> OrderItems { get; set; }

    }
}
