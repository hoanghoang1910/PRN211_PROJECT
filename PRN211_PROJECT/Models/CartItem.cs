﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Models
{
    internal class CartItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public float TotalPrice { get; set; }

    }
}
