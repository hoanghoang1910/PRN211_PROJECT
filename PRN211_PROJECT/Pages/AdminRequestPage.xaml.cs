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
    /// Interaction logic for AdminRequest.xaml
    /// </summary>
    public partial class AdminRequest : Page
    {
        public AdminRequest()
        {
            InitializeComponent();
            NewRequestCard.Visibility = Visibility.Visible;
            NewRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 167, 179, 234));
            OldRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 48, 63, 133));
            OldRequestCard.Visibility = Visibility.Hidden;
        }

        private void NewRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            NewRequestCard.Visibility = Visibility.Visible;
            NewRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 167, 179, 234));
            OldRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 48, 63, 133));
            OldRequestCard.Visibility = Visibility.Hidden;
        }

        private void OldRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            NewRequestCard.Visibility = Visibility.Hidden;
            OldRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 167, 179, 234));
            NewRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 48, 63, 133));
            OldRequestCard.Visibility = Visibility.Visible;
        }
    }
}
