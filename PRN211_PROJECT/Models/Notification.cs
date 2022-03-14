using System;
using System.Collections.Generic;

#nullable disable

namespace PRN211_PROJECT.Models
{
    public partial class Notification
    {
        public int NotificationId { get; set; }
        public string NotificationMessage { get; set; }
        public int NotiType { get; set; }
        public int? NotiFrom { get; set; }

        public virtual Store NotiFromNavigation { get; set; }
        public virtual NotifyType NotiTypeNavigation { get; set; }
    }
}
