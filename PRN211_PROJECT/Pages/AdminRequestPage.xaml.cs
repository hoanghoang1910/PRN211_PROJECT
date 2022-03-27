using Microsoft.Extensions.Configuration;
using PRN211_PROJECT.Models;
using PRN211_PROJECT.Repository;
using System;
using System.Collections.Generic;
using System.IO;
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

        IRequestRepository requestRepository;

        public AdminRequest(IRequestRepository requestRepository)
        {
            InitializeComponent();
            this.requestRepository = requestRepository;
        }

        private void NewRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadNewRequest();
            NewRequestCard.Visibility = Visibility.Visible;
            NewRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 167, 179, 234));
            OldRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 48, 63, 133));
            OldRequestCard.Visibility = Visibility.Hidden;
        }

        private void OldRequestBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadOldRequest();
            NewRequestCard.Visibility = Visibility.Hidden;
            OldRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 167, 179, 234));
            NewRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 48, 63, 133));
            OldRequestCard.Visibility = Visibility.Visible;
        }

        private void LoadNewRequest()
        {
            NewRequestLv.ItemsSource = requestRepository.GetRequestsRemaining();
        }

        private void LoadOldRequest()
        {
            OldRequestLv.ItemsSource = requestRepository.GetRequestHandled();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadNewRequest();
            NewRequestCard.Visibility = Visibility.Visible;
            NewRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 167, 179, 234));
            OldRequestBtn.Background = new SolidColorBrush(Color.FromArgb(100, 48, 63, 133));
            OldRequestCard.Visibility = Visibility.Hidden;
        }

        private void Accept_btn_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListViewItem)NewRequestLv.ContainerFromElement((Button)sender));
            Request request = curItem.DataContext as Request;
            if (requestRepository.AcceptRequest(request))
            {
                MessageBox.Show($"Request id {request.RequestId} approved");
                LoadNewRequest();
                var config = new ConfigurationBuilder().AddJsonFile("AppConfig.json").Build();
                string rootDir = config.GetSection("NotiCountPath").Value.ToString();
                int currentNotiCount = int.Parse(File.ReadAllText(rootDir)) + 1;
                File.WriteAllText(rootDir, currentNotiCount.ToString());
                AdminWindow main = Window.GetWindow(this) as AdminWindow;
                main.UpdateNoticount();
            }
            else
            {
                MessageBox.Show("Product quantity in stock is not enough");
            }
        }

        private void Deny_dtn_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListViewItem)NewRequestLv.ContainerFromElement((Button)sender));
            Request request = curItem.DataContext as Request;
            requestRepository.DenyRequest(request);
            MessageBox.Show($"Request id {request.RequestId} denied");
            LoadNewRequest();
            var config = new ConfigurationBuilder().AddJsonFile("AppConfig.json").Build();
            string rootDir = config.GetSection("NotiCountPath").Value.ToString();
            int currentNotiCount = int.Parse(File.ReadAllText(rootDir)) + 1;
            File.WriteAllText(rootDir, currentNotiCount.ToString());
            AdminWindow main = Window.GetWindow(this) as AdminWindow;
            main.UpdateNoticount();
        }
    }
}
