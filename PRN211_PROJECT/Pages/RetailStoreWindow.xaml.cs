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
    /// Interaction logic for RetailStoreWindow.xaml
    /// </summary>
    public partial class RetailStoreWindow : Window
    {
        public RetailStoreWindow()
        {
            InitializeComponent();
            renderBody.Content = new RetailRequestViewPage();
        }

        private void product_btn_Click(object sender, RoutedEventArgs e)
        {
            renderBody.Content = new ProductViewPage();
        }

        private void order_btn_Click(object sender, RoutedEventArgs e)
        {
            renderBody.Content = new OrderViewPage();   
        }

        private void requestRestock_btn_Click(object sender, RoutedEventArgs e)
        {
            renderBody.Content = new RetailRequestViewPage();
        }
    }
}
