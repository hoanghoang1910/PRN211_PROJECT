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
        public AdminWindow(IRequestRepository requestRepository, ICategoryRepository categoryRepository,
            IAdminStockRepository adminStockRepository, IStoreStockRepository storeStockRepository,
            IStoreRepository storeRepository, ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository)
        {
            InitializeComponent();
            renderBody.Content = new AdminDashboardPage();
            this.requestRepository = requestRepository;
            this.adminStockRepository = adminStockRepository;
            this.categoryRepository = categoryRepository;
            this.storeRepository = storeRepository;
            this.storeStockRepository = storeStockRepository;
            this.saleDetailRepository = saleDetailRepository;
            this.saleRepository = saleRepository;
        }

        private void resetSelection()
        {
            Style st = FindResource("menuButton") as Style;
            DashboardBtn.Style = st;
            RequestBtn.Style = st;
            StockBtn.Style = st;
            OrderBtn.Style = st;
            StatisticsBtn.Style = st;
            RevenueBtn.Style = st;
            NotificationBtn.Style = st;
            LogoutBtn.Style = st;
        }

        private void DashboardBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            DashboardBtn.Style = st;
            renderBody.Content = new AdminDashboardPage();

        }

        private void RequestBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            RequestBtn.Style = st;
            renderBody.Content = new AdminRequest(requestRepository);
        }

        private void StockBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            StockBtn.Style = st;
            renderBody.Content = new AdminStockPage(adminStockRepository, categoryRepository, 
                storeStockRepository, storeRepository);
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            OrderBtn.Style = st;
            renderBody.Content = new AdminOrderPage(saleRepository, saleDetailRepository, storeRepository);
        }

        private void StatisticsBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            StatisticsBtn.Style = st;
        }

        private void RevenueBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            RevenueBtn.Style = st;
        }

        private void NotificationBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            NotificationBtn.Style = st;
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {
            resetSelection();
            Style st = FindResource("menuButtonActive") as Style;
            LogoutBtn.Style = st;
        }
    }
}
