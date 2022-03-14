using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class Store
    {
        public Store()
        {
            Notifications = new HashSet<Notification>();
            Requests = new HashSet<Request>();
            Sales = new HashSet<Sale>();
            StoreStocks = new HashSet<StoreStock>();
        }

        public int StoreId { get; set; }
        public string StoreAddress { get; set; }
        public string StoreName { get; set; }
        public string StorePhoneNumber { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Request> Requests { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
        public virtual ICollection<StoreStock> StoreStocks { get; set; }
    }
}
