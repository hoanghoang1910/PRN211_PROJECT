using PRN211_PROJECT.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Shapes;

namespace PRN211_PROJECT.Pages
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        IRequestRepository requestRepository;
        ICategoryRepository categoryRepository;
        IAdminStockRepository adminStockRepository;
        IStoreRepository storeRepository;
        IStoreStockRepository storeStockRepository;
        ISaleRepository saleRepository;
        ISaleDetailRepository saleDetailRepository;
        INotificationRepository notificationRepository;
        IProductRepository productRepository;
        ILoginInfoRepository loginInfoRepository;
        public AdminWindow(IRequestRepository requestRepository, ICategoryRepository categoryRepository,
            IAdminStockRepository adminStockRepository, IStoreStockRepository storeStockRepository,
            IStoreRepository storeRepository, ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository,
            INotificationRepository notificationRepository, ILoginInfoRepository loginInfoRepository, IProductRepository productRepository)
        {
            InitializeComponent();
            renderBody.Content = new AdminDashboardPage(requestRepository, saleRepository);
            this.requestRepository = requestRepository;
            this.adminStockRepository = adminStockRepository;
            this.categoryRepository = categoryRepository;
            this.storeRepository = storeRepository;
            this.storeStockRepository = storeStockRepository;
            this.saleDetailRepository = saleDetailRepository;
            this.saleRepository = saleRepository;
            this.notificationRepository = notificationRepository;
            this.productRepository = productRepository;
            this.loginInfoRepository = loginInfoRepository;
            UpdateNoticount();
        }

        public void resetSelection()
        {
            Style st = FindResource("menuButton") as Style;
            DashboardBtn.Style = st;
            RequestBtn.Style = st;
            StockBtn.Style = st;
            OrderBtn.Style = st;
            NotificationBtn.Style = st;
            LogoutBtn.Style = st;
        }

        private void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            DashboardBtn.Style = st;
            renderBody.Content = new AdminDashboardPage(requestRepository, saleRepository);
        }

        public void RequestBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            RequestBtn.Style = st;
            renderBody.Content = new AdminRequest(requestRepository);
        }

        public void StockBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            StockBtn.Style = st;
            renderBody.Content = new AdminStockPage(adminStockRepository, categoryRepository, 
                storeStockRepository, storeRepository);
        }

        public void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            OrderBtn.Style = st;
            renderBody.Content = new AdminOrderPage(saleRepository, saleDetailRepository, storeRepository);
        }


        private void NotificationBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            NotificationBtn.Style = st;
            renderBody.Content = new AdminNotificationPage(notificationRepository);
            NotiNumber.Badge = "0";
            File.WriteAllText(@"D:\Spring2022\PRN211\FinalProject\PRN211_PROJECT\PRN211_PROJECT\NotiCount.txt", "0");
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            LogoutBtn.Style = st;
            LoginWindow dialog = new LoginWindow(requestRepository, categoryRepository, adminStockRepository, 
                storeStockRepository, storeRepository, saleRepository,
                saleDetailRepository, notificationRepository, productRepository, loginInfoRepository);
            dialog.Show();
            this.Close();
        }

        public void UpdateNoticount()
        {
            string notiNumber = File.ReadAllText(@"D:\Spring2022\PRN211\FinalProject\PRN211_PROJECT\PRN211_PROJECT\NotiCount.txt");
            NotiNumber.Badge = notiNumber;
        }
    }
}
