using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using StockWatcher.Models;
using StockWatcher.Services;
using StockWatcher.Services.Interfaces;
using StockWatcher.Services.Services;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.Configurations
{
    public static class Configuration
    {
        private static ServiceCollection _services;


        public static void Build()
        {
            BuildInjectionContainer();

            var settings = BuildConfiguration();

            _services.ConfigureSystemSettings(settings);
        }

        private static ApplicationSettings BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();

#if DEBUG
            builder.AddJsonFile("appSettings-debug.json", false);
#else
            builder.AddJsonFile("appsettings-secrets.json", false);
#endif

            var config = builder.Build();

            return config.Get<ApplicationSettings>();
        }

        private static void BuildInjectionContainer()
        {
            _services = new ServiceCollection();

            _services.ConfigureServices();
            
            _services.ConfigureViewModels();

            var provider = _services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);
        }
    }
}
