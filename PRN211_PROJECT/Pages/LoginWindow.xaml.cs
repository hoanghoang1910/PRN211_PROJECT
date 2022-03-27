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
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderBody.Content = new LoginRetail();
        }

        private void admin_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_btn.Visibility = Visibility.Hidden;
            retail_btn.Visibility = Visibility.Visible;
            RenderBody.Content = new LoginAdmin();
        }

        private void retail_btn_Click(object sender, RoutedEventArgs e)
        {
            admin_btn.Visibility = Visibility.Visible;
            retail_btn.Visibility = Visibility.Hidden;
            RenderBody.Content = new LoginRetail();
        }

        private void window_close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
