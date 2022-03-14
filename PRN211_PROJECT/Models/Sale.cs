using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public decimal? Bill { get; set; }
        public int StoreId { get; set; }
        public double SaleCoupon { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
