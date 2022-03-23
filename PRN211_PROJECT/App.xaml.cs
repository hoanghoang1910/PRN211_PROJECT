using Microsoft.Extensions.DependencyInjection;
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
            services.AddSingleton(typeof(IProductRepository), typeof(ProductRepository));
            services.AddSingleton<OrderModifyWindow>();
            services.AddSingleton<AdminWindow>();
        }

        private void OnStartUp(object sender, StartupEventArgs e)
        {
            var StartUpWindow = serviceProvider.GetService<AdminWindow>();
            StartUpWindow?.Show();
        }
    }
}
