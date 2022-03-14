using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class NotifyType
    {
        public NotifyType()
        {
            Notifications = new HashSet<Notification>();
        }

        public int NotiTypeId { get; set; }
        public string NotiTypeName { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
