using PRN211_PROJECT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.Repository
{
    public interface INotificationRepository
    {
        List<Notification> GetNotifications();
    }
}
