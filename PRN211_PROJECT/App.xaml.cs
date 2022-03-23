﻿using Microsoft.Extensions.DependencyInjection;
using PRN211_PROJECT.Pages;
using PRN211_PROJECT.Repository;
using PRN211_PROJECT.RepositoryImplementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PRN211_PROJECT
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            //Repo
            services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
            services.AddSingleton(typeof(ISaleDetailRepository), typeof(SaleDetailRepository));
            services.AddSingleton(typeof(ISaleRepository), typeof(SaleRepository));
            services.AddSingleton(typeof(IStoreRepository), typeof(StoreRepository));
            services.AddSingleton(typeof(IStoreStockRepository), typeof(StoreStockRepository));
            // Pages
            services.AddSingleton<OrderModifyWindow>();
            services.AddSingleton<AdminWindow>();
            services.AddSingleton<OrderDetailViewWindow>();
            services.AddSingleton<RetailStoreWindow>();
            services.AddSingleton<RetailRequestViewPage>();
            services.AddSingleton<ProductViewPage>();
            services.AddSingleton<OrderViewPage>();
        }

        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var StartUpWindow = serviceProvider.GetService<OrderDetailViewWindow>();
            StartUpWindow?.Show();
        }
    }
}
