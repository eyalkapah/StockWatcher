using StockWatcher.Configurations;
using StockWatcher.Services.Interfaces;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Messaging;
using StockWatcher.Models.Messages;

namespace StockWatcher
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration Configuration { get; }


        public App()
        {
            Configuration = BuildConfiguration();

            var services = new ServiceCollection();

            ConfigureServices(services);

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            WeakReferenceMessenger.Default.Register<ShutdownMessage>(this, (recipient, message) =>
            {
                Current.Shutdown();
            });
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureServices();

            services.ConfigureViewModels();

            services.ConfigureApplicationSettings();
            
            services.ConfigureDb(Configuration, "StockWatcher");

            var provider = services.BuildServiceProvider();

            Ioc.Default.ConfigureServices(provider);
        }

        private static IConfiguration BuildConfiguration()
        {
            var builder = new ConfigurationBuilder();

#if DEBUG
            builder.AddJsonFile("appSettings-debug.json", false);
#else
            builder.AddJsonFile("appsettings-secrets.json", false);
#endif

            return builder.Build();
        }
    }
}
