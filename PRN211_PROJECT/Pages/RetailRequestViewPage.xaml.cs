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
    /// Interaction logic for RetailRequestViewPage.xaml
    /// </summary>
    public partial class RetailRequestViewPage : Page
    {
        IRequestRepository _requestRepository;
        IProductRepository _productRepository;

        private List<Request> requests;
        private int _storeId;
        public RetailRequestViewPage(int storeId, IRequestRepository requestRepository, IProductRepository productRepository)
        {
            _requestRepository = requestRepository;
            _productRepository = productRepository;
            _storeId = storeId;

            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListBinding();
        }

        void ListBinding()
        {
            requests = _requestRepository.GetAllRequestFromRetail(_storeId);
            req_lv.ItemsSource = requests;

        }

        private void add_req_btn_Click(object sender, RoutedEventArgs e)
        {
            AddRequestWindow window = new AddRequestWindow();
            window.ShowDialog();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            var startDate = start_dp.SelectedDate;
            var endDate = end_dp.SelectedDate;
            if (startDate == null || endDate == null)
            {
                MessageBox.Show("you must enter both start date and end date");
                return;
            }

            requests = _requestRepository.GetRequestsFromBetweenDate(_storeId, startDate.Value, endDate.Value);
            req_lv.ItemsSource = requests;
        }
    }
}
