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
    /// Interaction logic for LoginRetail.xaml
    /// </summary>
    public partial class LoginRetail : Page
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
        public LoginRetail(IRequestRepository requestRepository, ICategoryRepository categoryRepository,
            IAdminStockRepository adminStockRepository, IStoreStockRepository storeStockRepository,
            IStoreRepository storeRepository, ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository,
            INotificationRepository notificationRepository, IProductRepository productRepository, ILoginInfoRepository loginInfoRepository)
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

        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            int check = loginInfoRepository.CheckLoginForSaler(NameTextBox.Text, PasswordBox.Password.ToString());
            if(check != 0)
            {
                RetailStoreWindow dialog = new RetailStoreWindow(storeStockRepository, saleRepository, storeRepository, 
                    requestRepository, categoryRepository,productRepository,adminStockRepository,notificationRepository,
                    loginInfoRepository,saleDetailRepository,check);
                dialog.Show();
                var win = Window.GetWindow(this);
                if (win != null)
                {
                    win.Close();
                }
            }
            else
            {
                MessageBox.Show("Login failed");
            }
        }
    }
}
