using PRN211_PROJECT.Models;
using PRN211_PROJECT.Repository;
using PRN211_PROJECT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRN211_PROJECT.RepositoryImplementation
{
    class NotificationRepository : INotificationRepository
    {
        public List<Notification> GetNotifications()
        {
            return NotificationService.Instance.GetNotifications();
        }
    }
}
