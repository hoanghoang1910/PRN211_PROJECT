using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class Product
    {
        public Product()
        {
            Requests = new HashSet<Request>();
            SaleDetails = new HashSet<SaleDetail>();
            StoreStocks = new HashSet<StoreStock>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public double Sale { get; set; }

        public virtual Category Category { get; set; }
        public virtual AdminStock AdminStock { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
        public virtual ICollection<StoreStock> StoreStocks { get; set; }
    }
}
