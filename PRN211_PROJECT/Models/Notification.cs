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
        public DateTime? NotiDate { get; set; }

        public virtual Store NotiFromNavigation { get; set; }
        public virtual NotifyType NotiTypeNavigation { get; set; }

        public string GetIcon
        {
            get
            {
                if(NotiType == 1)
                {
                    return "PlusCircle";
                }
                else if(NotiType == 2)
                {
                    return "Edit";
                }
                else if(NotiType == 3)
                {
                    return "Check";
                }
                else if(NotiType == 4)
                {
                    return "WindowClose";
                }
                else if(NotiType == 5)
                {
                    return "Plus";
                }
                else
                {
                    return "CartPlus";
                }
            }
        }
    }
}
