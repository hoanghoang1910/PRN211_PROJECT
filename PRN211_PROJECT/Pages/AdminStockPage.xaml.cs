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
    /// Interaction logic for AdminStockPage.xaml
    /// </summary>
    public partial class AdminStockPage : Page
    {
        IAdminStockRepository adminStockRepository;
        ICategoryRepository categoryRepository;
        IStoreRepository storeRepository;
        IStoreStockRepository storeStockRepository;
        public AdminStockPage(IAdminStockRepository adminStockRepository, ICategoryRepository categoryRepository, IStoreStockRepository storeStockRepository, IStoreRepository storeRepository)
        {
            InitializeComponent();
            this.adminStockRepository = adminStockRepository;
            this.categoryRepository = categoryRepository;
            this.storeRepository = storeRepository;
            this.storeStockRepository = storeStockRepository;
        }

        private void LoadStockListView()
        {
            AdminStockLv.ItemsSource = adminStockRepository.GetAllAdminStock();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            AdminStockGrid.Visibility = Visibility.Visible;
            StoreStockGrid.Visibility = Visibility.Hidden;
            LoadStockListView();
            List<Category> list = categoryRepository.GetCategories();
            list.Insert(0, new Category { CategoryId = 0, CategoryName = "Any", CategoryDescription = "" });
            FilterCategoryCb.ItemsSource = list;
            FilterCategoryCb.DisplayMemberPath = "CategoryName";
            FilterCategoryCb.SelectedValuePath = "CategoryId";
            FilterCategoryCb.SelectedValue = 0;
            CategoryComboBox.ItemsSource = categoryRepository.GetCategories();
            CategoryComboBox.DisplayMemberPath = "CategoryName";
            CategoryComboBox.SelectedValuePath = "CategoryId";
            List<Store> storeList = storeRepository.GetAllStore();
            storeList.Insert(0, new Store { StoreId = 0, StoreName = "Any" });
            ssStorCb.ItemsSource = storeList;
            ssStorCb.DisplayMemberPath = "StoreName";
            ssStorCb.SelectedValuePath = "StoreId";
            ssStorCb.SelectedValue = 0;
            ssCategoryCb.ItemsSource = list;
            ssCategoryCb.DisplayMemberPath = "CategoryName";
            ssCategoryCb.SelectedValuePath = "CategoryId";
            ssCategoryCb.SelectedValue = 0;
            StoreStockLv.ItemsSource = storeStockRepository.GetAllStoreStock();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {

            string price = ProductPriceTb.Text;
            decimal result = 0;
            if (price != "" && price.Contains('.'))
            {
                string[] split = price.Split('.');
                result = decimal.Parse(split[0]) + decimal.Parse("0," + split[1]);
            }
            else
            {
                result = decimal.Parse(price);
            }
            AdminStock adminStock = (AdminStock)AdminStockLv.SelectedItem;
            adminStock.Product.ProductName = ProductNameTb.Text;
            adminStock.Product.Price = result;
            adminStock.Product.Sale = double.Parse(SaleTb.Text);
            adminStock.Product.Category = (Category)CategoryComboBox.SelectedItem;
            adminStock.Quantity = int.Parse(QuantityTb.Text);
            adminStockRepository.UpdateAdminStock(adminStock);
            LoadStockListView();
            int currentNotiCount = int.Parse(File.ReadAllText(@"D:\Spring2022\PRN211\FinalProject\PRN211_PROJECT\PRN211_PROJECT\NotiCount.txt")) + 1;
            File.WriteAllText(@"D:\Spring2022\PRN211\FinalProject\PRN211_PROJECT\PRN211_PROJECT\NotiCount.txt", currentNotiCount.ToString());
            AdminWindow main = Window.GetWindow(this) as AdminWindow;
            main.UpdateNoticount();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string price = ProductPriceTb.Text;
            decimal result = 0;
            if (price != "" && price.Contains('.'))
            {
                string[] split = price.Split('.');
                result = decimal.Parse(split[0]) + decimal.Parse("0," + split[1]);
            }
            else
            {
                result = decimal.Parse(price);
            }
            Product p = new Product
            {
                ProductName = ProductNameTb.Text,
                Price = result,
                Sale = double.Parse(SaleTb.Text),
                CategoryId = int.Parse(CategoryComboBox.SelectedValue.ToString())
            };
            int quantity = int.Parse(QuantityTb.Text);
            adminStockRepository.AddProductToStock(p, quantity);
            LoadStockListView();
            int currentNotiCount = int.Parse(File.ReadAllText(@"D:\Spring2022\PRN211\FinalProject\PRN211_PROJECT\PRN211_PROJECT\NotiCount.txt")) + 1;
            File.WriteAllText(@"D:\Spring2022\PRN211\FinalProject\PRN211_PROJECT\PRN211_PROJECT\NotiCount.txt", currentNotiCount.ToString());
            AdminWindow main = Window.GetWindow(this) as AdminWindow;
            main.UpdateNoticount();
        }

        private void Search()
        {
            string productName = FilterProductNameTb.Text;
            int id = int.Parse(FilterCategoryCb.SelectedValue.ToString());
            if (productName != "" && id != 0)
            {
                AdminStockLv.ItemsSource = adminStockRepository.GetAdminStockFilterByBoth(id, productName);
            }
            else if (productName != "" && id == 0)
            {
                AdminStockLv.ItemsSource = adminStockRepository.GetAdminStockFilterByName(productName);
            }
            else if (productName == "" && id != 0)
            {
                AdminStockLv.ItemsSource = adminStockRepository.GetAllAdminStockFilterByCategory(id);
            }
            else
            {
                LoadStockListView();
            }
        }

        private void FilterProductNameTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search();
        }

        private void FilterCategoryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Search();
        }

        private void ChangeLayoutBtn_Click(object sender, RoutedEventArgs e)
        {
            AdminStockGrid.Visibility = Visibility.Hidden;
            StoreStockGrid.Visibility = Visibility.Visible;
        }

        private void ChangeLayoutBtn2_Click(object sender, RoutedEventArgs e)
        {
            AdminStockGrid.Visibility = Visibility.Visible;
            StoreStockGrid.Visibility = Visibility.Hidden;
        }

        private void FilterInStoreStock()
        {
            try
            {
                int storeId = int.Parse(ssStorCb.SelectedValue.ToString());
                int categoryId = int.Parse(ssCategoryCb.SelectedValue.ToString());
                if (categoryId == 0 && storeId == 0)
                {
                    StoreStockLv.ItemsSource = storeStockRepository.GetAllStoreStock();
                }
                else if (categoryId != 0 && storeId != 0)
                {
                    StoreStockLv.ItemsSource = storeStockRepository.GetProductFromStockByCategoryAndStore(categoryId, storeId);
                }
                else if (categoryId != 0 && storeId == 0)
                {
                    StoreStockLv.ItemsSource = storeStockRepository.GetProductFromStockByCategory(categoryId);
                }
                else
                {
                    StoreStockLv.ItemsSource = storeStockRepository.GetAllProductFromStock(storeId);
                }
            }
            catch(NullReferenceException e)
            {
                
            }
        }

        private void ssCategoryCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterInStoreStock();
        }

        private void ssStorCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterInStoreStock();
        }
    }
}
