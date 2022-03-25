using PRN211_PROJECT.Models;
using PRN211_PROJECT.Repository;
using PRN211_PROJECT.RepositoryImplementation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        List<StoreStock> _orders;
        ObservableCollection<CartItem> _cartItems;

        private IProductRepository _productRepository;
        private ISaleRepository _saleRepository;
        private ISaleDetailRepository _saleDetailRepository;
        private IStoreStockRepository _stockRepository;
        private int _storeId;

        public OrderModifyWindow(IProductRepository productRepository, ISaleDetailRepository saleDetailRepository, ISaleRepository saleRepository, int storeId, IStoreStockRepository stockRepository)
        {
            _productRepository = productRepository;
            _saleDetailRepository = saleDetailRepository;
            _saleRepository = saleRepository;
            _stockRepository = stockRepository;
            _storeId = storeId;

            _cartItems = new ObservableCollection<CartItem>();

            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ListBinding();
        }

        private void ListBinding()
        {
            _orders = _stockRepository.GetAllProductFromStock(_storeId);
            product_lb.ItemsSource = _orders;
            Cart_lv.ItemsSource = _cartItems;
        }

        private float UpdateTotalPrice()
        {
            var totalPrice = 0f;
            foreach (var item in _cartItems)
            {
                totalPrice += item.TotalPrice;
            }
            total_price_tb.Text = $"Total Price : {totalPrice}";
            return totalPrice;
        }

        private void add_item_btn_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListViewItem)product_lb.ContainerFromElement((Button)sender));
            var selected = curItem.DataContext as StoreStock;
            //MessageBox.Show($"Selected index = {selected.ProductName}");

            if (selected != null)
            {
                var cartItem = _cartItems.FirstOrDefault(x => x.Product.ProductId == selected.ProductId);

                if (cartItem == null)
                {
                    cartItem = new CartItem() { Product = selected.Product, Quantity = 1, TotalPrice = (float)selected.Product.Price };
                    _cartItems.Add(cartItem);
                }
                else
                {
                    cartItem.Quantity++;
                    cartItem.TotalPrice = (float)cartItem.Product.Price * cartItem.Quantity;
                    Cart_lv.Items.Refresh();
                }
                product_name_tb.Text = selected.Product.ProductName;
                product_des_tb.Text = selected.Product.Description;
            }
            UpdateTotalPrice();
        }

        private void plus_quantity_btn_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListViewItem)Cart_lv.ContainerFromElement((Button)sender));
            var selected = curItem?.DataContext as CartItem;
            if (selected != null)
            {
                selected.Quantity++;
                selected.TotalPrice = (float)selected.Product.Price * selected.Quantity;
                Cart_lv.Items.Refresh();
            }
            UpdateTotalPrice();
        }

        private void minus_quantity_btn_Click(object sender, RoutedEventArgs e)
        {
            var curItem = ((ListViewItem)Cart_lv.ContainerFromElement((Button)sender));
            var selected = curItem?.DataContext as CartItem;
            if (selected != null)
            {
                selected.Quantity--;
                selected.TotalPrice = (float)selected.Product.Price * selected.Quantity;
                Cart_lv.Items.Refresh();
                if (selected.Quantity <= 0)
                {
                    _cartItems.Remove(selected);
                    Cart_lv.Items.Refresh();
                }
            }
            UpdateTotalPrice();
        }

        private void window_close_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void remove_btn_Click(object sender, RoutedEventArgs e)
        {
            _cartItems.Clear();
            UpdateTotalPrice();
        }

        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            Sale saleToAdd = new Sale()
            {
                StoreId = _storeId,
                SaleDate = DateTime.Now,
                Bill = (decimal)UpdateTotalPrice(),
                SaleCoupon = Convert.ToDouble(coupon_tb.Text == "" ? 0 : coupon_tb.Text)
            };
            _saleRepository.AddSale(saleToAdd);
            var saleId = saleToAdd.SaleId;
            foreach (var item in _cartItems)
            {
                var obj = new SaleDetail()
                {
                    SaleId = saleId,
                    ProductId = item.Product.ProductId,
                    Quantity = item.Quantity,
                };
                _stockRepository.CheckoutProductFromStock(obj.ProductId, obj.Quantity, _storeId);
                _saleDetailRepository.AddSaleDetail(obj);
            }
            this.Close();
        }
    }
}
