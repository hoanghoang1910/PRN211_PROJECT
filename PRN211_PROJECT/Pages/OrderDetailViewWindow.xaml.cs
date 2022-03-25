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
    /// Interaction logic for OrderDetailViewWindow.xaml
    /// </summary>
    public partial class OrderDetailViewWindow : Window
    {
        private List<SaleDetail> saleDetails;
        private ISaleDetailRepository _saleDetailRepository;
        private int _saleId;
        private Sale curSale;

        public OrderDetailViewWindow(int saleId, ISaleDetailRepository saleDetailRepository)
        {
            this._saleId = saleId;
            _saleDetailRepository = saleDetailRepository;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListBinding();
        }

        private void ListBinding()
        {
            saleDetails = _saleDetailRepository.SaleDetailListBySaleId(_saleId);
            if (saleDetails.Count == 0) return;
            curSale = saleDetails.FirstOrDefault().Sale;
            sale_lv.ItemsSource = saleDetails;

            id_tb.Text = curSale.SaleId.ToString();
            date_tb.Text = curSale.SaleDate.ToString();
            bill_tb.Text = curSale.Bill.ToString();
            coupon_tb.Text = curSale.SaleCoupon.ToString() + "%";

            var discountBill = curSale.Bill * (Convert.ToDecimal(curSale.SaleCoupon) / 100);
            realbill_tb.Text = (curSale.Bill - discountBill).ToString();

        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
