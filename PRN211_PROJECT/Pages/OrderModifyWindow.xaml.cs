using PRN211_PROJECT.Models;
using PRN211_PROJECT.Repository;
using PRN211_PROJECT.RepositoryImplementation;
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
    /// Interaction logic for OrderModifyWindow.xaml
    /// </summary>
    public partial class OrderModifyWindow : Window
    {
        List<Product> orders = new List<Product>();

        private IProductRepository _productRepository;

        public OrderModifyWindow(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            orders = _productRepository.GetAllProducts();
            product_lb.ItemsSource = orders;
        }

        private void add_item_btn_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListViewItem)product_lb.ContainerFromElement((Button)sender));
            var selected = curItem.DataContext as Product;
            MessageBox.Show($"Selected index = {selected.ToString()}");
        }

    }
}
