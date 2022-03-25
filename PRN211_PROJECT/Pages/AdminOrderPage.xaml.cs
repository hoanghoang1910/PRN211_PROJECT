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
    /// Interaction logic for AdminOrderPage.xaml
    /// </summary>
    public partial class AdminOrderPage : Page
    {
        ISaleRepository saleRepository;
        ISaleDetailRepository saleDetailRepository;
        IStoreRepository storeRepository;
        public AdminOrderPage(ISaleRepository saleRepository, ISaleDetailRepository saleDetailRepository, IStoreRepository storeRepository)
        {
            this.storeRepository = storeRepository;
            this.saleDetailRepository = saleDetailRepository;
            this.saleRepository = saleRepository;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            OrderLv.ItemsSource = saleRepository.GetAllSale();
            List<Store> storeList = storeRepository.GetAllStore();
            storeList.Insert(0, new Store { StoreId = 0, StoreName = "Any" });
            StoreCb.ItemsSource = storeList;
            StoreCb.DisplayMemberPath = "StoreName";
            StoreCb.SelectedValuePath = "StoreId";
            StoreCb.SelectedValue = 0;
        }

        private void OrderLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrderLv.SelectedItem != null)
            {
                Sale sale = (Sale)OrderLv.SelectedItem;
                SaleDetailsLv.ItemsSource = saleDetailRepository.SaleDetailListBySaleId(sale.SaleId);
            }
        }

        private void Search()
        {
            int storeId = int.Parse(StoreCb.SelectedValue.ToString());
            if (DateFromPicker.SelectedDate != null && DateToPicker.SelectedDate != null)
            {
                DateTime dateFrom = (DateTime)DateFromPicker.SelectedDate;
                DateTime dateTo = (DateTime)DateToPicker.SelectedDate;
                OrderLv.ItemsSource = saleRepository.GetSalesByStoreIdWithDate(storeId, dateFrom, dateTo);
            }
            else
            {
                if (storeId != 0)
                {
                    OrderLv.ItemsSource = saleRepository.GetSalesByStoreId(storeId);
                }
                else
                {
                    OrderLv.ItemsSource = saleRepository.GetAllSale();
                }
            }
        }

        private void DateFromPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void DateToPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void StoreCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }
    }
}
