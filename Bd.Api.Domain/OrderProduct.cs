﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Bd.Api.Domain
{
    public class OrderProduct
    {
        public string OrderId { get; set; }

        public Order Order { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }
    }
}
