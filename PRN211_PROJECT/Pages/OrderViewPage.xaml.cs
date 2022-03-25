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
    /// Interaction logic for OrderViewPage.xaml
    /// </summary>
    public partial class OrderViewPage : Page
    {
        ISaleRepository _saleRepository;
        IProductRepository _productRepository;
        ISaleDetailRepository _saleDetailRepository;
        IStoreStockRepository _stockRepository;

        List<Sale> sales;
        private int _storeid;

        public OrderViewPage(int storeid, ISaleRepository saleRepository, IProductRepository productRepository, ISaleDetailRepository saleDetailRepository, IStoreStockRepository stockRepository)
        {
            _storeid = storeid;
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _saleDetailRepository = saleDetailRepository;
            _stockRepository = stockRepository;


            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListBinding();
        }

        public void ListBinding()
        {
            sales = _saleRepository.GetSalesByStoreId(_storeid);
            sale_lv.ItemsSource = sales;
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

            sales = _saleRepository.GetSalesByStoreIdWithDate(_storeid, (DateTime)startDate, (DateTime)endDate);
            sale_lv.ItemsSource = sales;
        }

        private void saleAdd_btn_Click(object sender, RoutedEventArgs e)
        {
            OrderModifyWindow window = new OrderModifyWindow(_productRepository, _saleDetailRepository, _saleRepository, _storeid, _stockRepository);
            window.ShowDialog();
            ListBinding();
        }

        private void saleDelete_btn_Click(object sender, RoutedEventArgs e)
        {
            var item = sale_lv.SelectedItem as Sale;
            _saleDetailRepository.DeleteSales(item.SaleId);
            _saleRepository.Delete(item);
            ListBinding();

        }

        private void view_item_btn_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListViewItem)sale_lv.ContainerFromElement((Button)sender));
            var selected = curItem.DataContext as Sale;
            if (selected != null)
            {
                OrderDetailViewWindow window = new OrderDetailViewWindow(selected.SaleId, _saleDetailRepository);
                window.ShowDialog();
            }
        }
    }
}
