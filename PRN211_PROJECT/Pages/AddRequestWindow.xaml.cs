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
using System.Windows.Shapes;

namespace PRN211_PROJECT.Pages
{
    /// <summary>
    /// Interaction logic for AddRequestWindow.xaml
    /// </summary>
    public partial class AddRequestWindow : Window
    {

        IProductRepository _productRepository;
        IRequestRepository _requestRepository;

        private int _storeId;

        List<Product> products;

        public AddRequestWindow(int storeId, IRequestRepository requestRepository, IProductRepository productRepository)
        {
            _requestRepository = requestRepository;
            _productRepository = productRepository;
            _storeId = storeId;

            InitializeComponent();
        }

        private void ListBinding()
        {
            products = _productRepository.GetAllProducts();
            list_lv.ItemsSource = products;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListBinding();
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            string searchText = search_tb.Text;
            if (searchText != "")
            {
                products = _productRepository.GetAllProductsWithSearch(searchText);
                list_lv.ItemsSource = products;
            }
            else
            {
                ListBinding();
            }
        }

        private void list_lv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = list_lv.SelectedItem as Product;
            if (selected != null)
            {
                name_tb.Text = selected.ProductName;
                category_tb.Text = selected.Category.CategoryName;
            }
        }

        private void confirm_request_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selected = list_lv.SelectedItem as Product;
                if (selected != null)
                {
                    Request requestToAdd = new Request()
                    {
                        ProductId = selected.ProductId,
                        StoreId = _storeId,
                        Message = message_tb.Text,
                        DateCreated = DateTime.Now,
                        Quantity = Convert.ToInt32(quantity_tb.Text),
                    };

                    _requestRepository.AddRequest(requestToAdd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void window_close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
