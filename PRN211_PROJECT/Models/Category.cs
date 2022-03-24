using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
