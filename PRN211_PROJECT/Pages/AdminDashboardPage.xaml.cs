using LiveCharts;
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
    /// Interaction logic for AdminDashboardPage.xaml
    /// </summary>
    public partial class AdminDashboardPage : Page
    {
        IRequestRepository requestRepository;
        ISaleRepository saleRepository;
        public AdminDashboardPage(IRequestRepository requestRepository, ISaleRepository saleRepository)
        {
            InitializeComponent();
            this.requestRepository = requestRepository;
            this.saleRepository = saleRepository;
            ResetBtn();
            TodayBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
            UpdateCardToday();
            UpdateTopFiveOrders();
            UpdateChart();
        }

        private void UpdateCardToday()
        {
            RequestCard.Number = requestRepository.GetNumberOfRequestsToday().ToString() + " requests";
            OrdersCard.Number = saleRepository.GetNumberOfOrdersToday().ToString() + " orders";
            IncomeCard.Number = "đ " + saleRepository.GetIncomeToday().ToString().Split(',')[0];
        }

        private void UpdateCardThisWeek()
        {
            RequestCard.Number = requestRepository.GetNumberOfRequestsThisWeek().ToString() + " requests";
            OrdersCard.Number = saleRepository.GetNumberOfOrdersThisWeek().ToString() + " orders";
            IncomeCard.Number = "đ " + saleRepository.GetIncomeThisWeek().ToString().Split(',')[0];
        }

        private void UpdateCardThisMonth()
        {
            RequestCard.Number = requestRepository.GetNumberOfRequestsThisMonth().ToString() + " requests";
            OrdersCard.Number = saleRepository.GetNumberOfOrdersThisMonth().ToString() + " orders";
            IncomeCard.Number = "đ " + saleRepository.GetIncomeThisMonth().ToString().Split(',')[0];
        }

        private void UpdateCardThisYear()
        {
            RequestCard.Number = requestRepository.GetNumberOfRequestsThisYear().ToString() + " requests";
            OrdersCard.Number = saleRepository.GetNumberOfOrdersThisYear().ToString() + " orders";
            IncomeCard.Number = "đ " + saleRepository.GetIncomeThisYear().ToString().Split(',')[0];
        }

        private void UpdateChart()
        {
            var tem1 = new ChartValues<decimal>();
            decimal[] chartValue = saleRepository.GetIncomeByMonthInYear();
            decimal maxValue = chartValue.Max();
            if (maxValue > 1000000)
            {
                ChartValue.MaxValue = 10500000;
                foreach (var tb in ProfitPanel.Children.OfType<TextBlock>())
                {
                    tb.Text = tb.Text+"0";
                }
            }
            else if(maxValue > 10000000)
            {
                ChartValue.MaxValue = 105000000;
                foreach (var tb in ProfitPanel.Children.OfType<TextBlock>())
                {
                    tb.Text = tb.Text + "00";
                }
            }
            else if (maxValue > 100000000)
            {
                ChartValue.MaxValue = 1050000000;
                foreach (var tb in ProfitPanel.Children.OfType<TextBlock>())
                {
                    tb.Text = tb.Text + "000";
                }
            }
            tem1.Add(0);
            foreach (decimal a in chartValue)
            {
                tem1.Add(a);
            }
            Slm.Values = tem1;
        }

        private void UpdateTopFiveOrders()
        {
            List<Sale> lastFiveOrders = saleRepository.GetTop5NewestOrder();
            LastOrder1.Title = lastFiveOrders[0].Store.StoreName;
            LastOrder2.Title = lastFiveOrders[1].Store.StoreName;
            LastOrder3.Title = lastFiveOrders[2].Store.StoreName;
            LastOrder4.Title = lastFiveOrders[3].Store.StoreName;
            LastOrder5.Title = lastFiveOrders[4].Store.StoreName;
            LastOrder1.Desc = lastFiveOrders[0].Bill.ToString().Split(',')[0] + " đ";
            LastOrder2.Desc = lastFiveOrders[1].Bill.ToString().Split(',')[0] + " đ";
            LastOrder3.Desc = lastFiveOrders[2].Bill.ToString().Split(',')[0] + " đ";
            LastOrder4.Desc = lastFiveOrders[3].Bill.ToString().Split(',')[0] + " đ";
            LastOrder5.Desc = lastFiveOrders[4].Bill.ToString().Split(',')[0] + " đ";
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
            UpdateCardToday();
        }

        private void ThisWeekBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBtn();
            ThisWeekBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
            UpdateCardThisWeek();
        }

        private void ThisMonthBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBtn();
            ThisMonthBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
            UpdateCardThisMonth();
        }

        private void ThisYearBtn_Click(object sender, RoutedEventArgs e)
        {
            ResetBtn();
            ThisYearBtn.Background = new SolidColorBrush(Color.FromArgb(100, 91, 96, 196));
            UpdateCardThisYear();
        }

        private void LastOrder1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadOrderContent(sender, e);
        }

        private void LastOrder2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadOrderContent(sender, e);
        }

        private void LastOrder3_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadOrderContent(sender, e);
        }

        private void LastOrder4_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadOrderContent(sender, e);
        }

        private void LastOrder5_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LoadOrderContent(sender, e);
        }

        private void LoadOrderContent(object sender, MouseButtonEventArgs e)
        {
            AdminWindow main = Window.GetWindow(this) as AdminWindow;
            main.OrderBtn_Click(sender, e);
        }
    }
}
