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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
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
        public LoginWindow(IRequestRepository requestRepository, ICategoryRepository categoryRepository,
            IAdminStockRepository adminStockRepository, IStoreStockRepository storeStockRepository,
            IStoreRepository storeRepository, ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository,
            INotificationRepository notificationRepository, IProductRepository productRepository , ILoginInfoRepository loginInfoRepository)
        {
            InitializeComponent();
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderBody.Content = new LoginRetail(requestRepository, categoryRepository, adminStockRepository,
                storeStockRepository, storeRepository, saleRepository, saleDetailRepository, notificationRepository,
                productRepository, loginInfoRepository);
        }

        private void admin_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_btn.Visibility = Visibility.Hidden;
            retail_btn.Visibility = Visibility.Visible;
            RenderBody.Content = new LoginAdmin(requestRepository,categoryRepository,adminStockRepository,
                storeStockRepository,storeRepository,saleRepository,saleDetailRepository,notificationRepository,
                productRepository,loginInfoRepository );
        }

        private void retail_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_btn.Visibility = Visibility.Visible;
            retail_btn.Visibility = Visibility.Hidden;
            RenderBody.Content = new LoginRetail(requestRepository, categoryRepository, adminStockRepository,
                storeStockRepository, storeRepository, saleRepository, saleDetailRepository, notificationRepository,
                productRepository, loginInfoRepository);
        }

        private void window_close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
