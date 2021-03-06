﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bd.Api.Domain
{
    [Table("Products")]
    public class Product
    {
        public Product()
        {
            OrderProducts = new List<OrderProduct>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public bool IsDeleted { get; set; }

        public bool IsBlocked { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }

    }
}
