﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bd.Api.Domain
{
    public class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string OrderItemId { get; set; }

        public string OrderId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string ProductType { get; set; }

        public DateTime CreatedDate { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public double TotalQuantityPrice { get; set; }

        public Order Order { get; set; }

        //public Product Product { get; set; }


    }
}
