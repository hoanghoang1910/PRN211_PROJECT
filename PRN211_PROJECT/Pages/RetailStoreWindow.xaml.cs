﻿using PRN211_PROJECT.Repository;
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
    /// Interaction logic for RetailStoreWindow.xaml
    /// </summary>
    public partial class RetailStoreWindow : Window
    {
        IStoreStockRepository _storeStockRepo;
        ISaleRepository _saleRepo;
        IStoreRepository _storeRepo;
        IRequestRepository _requestRepo;
        ICategoryRepository _categoryRepo;
        IProductRepository _productRepo;

        private int _storeId = 1;

        public RetailStoreWindow(IStoreStockRepository storeStockRepository
            , ISaleRepository saleRepository
            , IStoreRepository storeRepository
            , IRequestRepository requestRepository
            , ICategoryRepository categoryRepository
            , IProductRepository productRepository)
        {
            InitializeComponent();
            _storeStockRepo = storeStockRepository;
            _storeRepo = storeRepository;
            _saleRepo = saleRepository;
            _requestRepo = requestRepository;
            _categoryRepo = categoryRepository;
            _productRepo = productRepository;
            renderBody.Content = new ProductViewPage(_storeId, _storeStockRepo, _categoryRepo);
        }

        private void product_btn_Click(object sender, RoutedEventArgs e)
        {
            renderBody.Content = new ProductViewPage(_storeId, _storeStockRepo, _categoryRepo);
        }

        private void order_btn_Click(object sender, RoutedEventArgs e)
        {
            renderBody.Content = new OrderViewPage(_storeId, _saleRepo,_productRepo);
        }

        private void requestRestock_btn_Click(object sender, RoutedEventArgs e)
        {
            renderBody.Content = new RetailRequestViewPage();
        }
    }
}
