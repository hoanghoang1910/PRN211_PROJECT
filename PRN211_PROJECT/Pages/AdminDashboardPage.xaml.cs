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
    /// Interaction logic for AdminDashboardPage.xaml
    /// </summary>
    public partial class AdminDashboardPage : Page
    {
        public AdminDashboardPage()
        {
            InitializeComponent();
            ResetBtn();
            TodayBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));           
        }

        private void ResetBtn()
        {
            TodayBtn.Background = null;
            ThisMonthBtn.Background = null;
            ThisWeekBtn.Background = null;
            ThisYearBtn.Background = null;
        }

        private void TodayBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBtn();
            TodayBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
        }

        private void ThisWeekBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBtn();
            ThisWeekBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
        }

        private void ThisMonthBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBtn();
            ThisMonthBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
        }

        private void ThisYearBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBtn();
            ThisYearBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
        }
    }
}
