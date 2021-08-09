using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StockWatcher.Configurations;

namespace StockWatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var services = new ServiceCollection();

            services.ConfigureServices();

            services.ConfigureViewModels();

            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);
        }

        
    }
}
