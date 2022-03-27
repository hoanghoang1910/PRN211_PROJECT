using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class Request
    {
        public int RequestId { get; set; }
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Message { get; set; }
        public bool? Status { get; set; }
        public DateTime DateCreated { get; set; }

        public string StatusString
        {
            get
            {
                if(Status == null)
                {
                    return "Pending";
                }
                if ((bool)Status)
                {
                    return "Accepted";
                }
                else
                {
                    return "Rejected";
                }
            }
        }


        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
