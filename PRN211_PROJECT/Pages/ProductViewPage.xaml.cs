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
    /// Interaction logic for ProductViewPage.xaml
    /// </summary>
    public partial class ProductViewPage : Page
    {
        IStoreStockRepository _stockRepository;
        ICategoryRepository _categoryRepository;
        List<StoreStock> storeStocks;
        List<Category> categories;

        private int _storeId;

        public ProductViewPage(int storeId, IStoreStockRepository storeRepository
            , ICategoryRepository categoryRepository)
        {
            _storeId = storeId;
            _stockRepository = storeRepository;
            _categoryRepository = categoryRepository;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ListBinding();
            comboboxBinding();
        }

        private void ListBinding()
        {
            storeStocks = _stockRepository.GetAllProductFromStock(_storeId);
            product_lv.ItemsSource = storeStocks;
        }

        private void comboboxBinding()
        {
            categories = _categoryRepository.GetCategories();
            categories.Add(new Category { CategoryName = "All Category", CategoryId = -1, CategoryDescription = "" });
            categories.Reverse();
            category_cb.ItemsSource = categories;
            category_cb.DisplayMemberPath = "CategoryName";
            category_cb.SelectedValuePath = "CategoryId";
            category_cb.SelectedValue = -1;
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            var productName = searchBox_tb.Text;
            int categoryId = (int)category_cb.SelectedValue;

            if (productName == "" && categoryId != -1)
            {
                storeStocks = _stockRepository.GetAllProductFromStockWithCategory(_storeId, (int)categoryId);
            }
            else if (productName != "" && categoryId == -1)
            {
                storeStocks = _stockRepository.GetAllProductFromStockWithSearch(_storeId, productName);
            }
            else if (productName != "" && categoryId != -1)
            {
                storeStocks = _stockRepository.GetAllProductFromStockWithCategoryAndName(_storeId, productName, (int)categoryId);
            }
            else
            {
                ListBinding();
            }
            product_lv.ItemsSource = storeStocks;
        }
    }
}
