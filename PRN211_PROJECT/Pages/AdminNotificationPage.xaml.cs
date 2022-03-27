using PRN211_PROJECT.Models;
using PRN211_PROJECT.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRN211_PROJECT.Pages
{
    /// <summary>
    /// Interaction logic for AdminNotificationPage.xaml
    /// </summary>
    public partial class AdminNotificationPage : Page
    {
        INotificationRepository notificationRepository;
        public AdminNotificationPage(INotificationRepository notificationRepository)
        {
            InitializeComponent();
            this.notificationRepository = notificationRepository;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<Notification> list = notificationRepository.GetNotifications();
            foreach(Notification n in list)
            {
                if(n.NotiFromNavigation == null)
                {
                    n.NotiFromNavigation = new Store { StoreName = "From Admin" };
                }

            }
            ListBoxNoti.ItemsSource = list;
        }
    }
}
