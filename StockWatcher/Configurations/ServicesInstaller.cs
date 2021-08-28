using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using StockWatcher.Models.Settings;
using StockWatcher.Services;
using StockWatcher.Services.Interfaces;
using StockWatcher.Services.Services;

namespace StockWatcher.Configurations
{
    public static class ServicesInstaller
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddLogging(builder => builder.AddSerilog(dispose: true));

            return services.AddSingleton<ITextService, TextService>()
                .AddSingleton<ILogService, LogService>()
                .AddSingleton<INavigationService, NavigationService>()
                .AddSingleton<IAuthenticationService, AuthenticationService>()
                .AddSingleton<IDbService, DbService>()
                .AddSingleton<IStockService, StockService>()
                .AddSingleton<IStatusBarService, StatusBarService>()
                .AddSingleton<IThemeService, ThemeService>();

        }

        public static void ConfigureConditionalServices(this IServiceCollection services, IConfiguration configuration)
        {
            var dataProvider = configuration["DataProvider"];

            if (dataProvider.Equals("Yahoo"))
            {
                services.AddSingleton<IDataProviderService, YahooService>();
            }
        }

        public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration, string name)
        {
            var connectionString = configuration.GetConnectionString(name);

            services.AddSingleton<IDbService>(_ => new DbService(connectionString));
        }

        public static void ConfigureApplicationSettings(this IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();

#if DEBUG
            builder.AddJsonFile("appSettings-debug.json", false);
#else
            builder.AddJsonFile("appsettings-secrets.json", false);
#endif

            var config = builder.Build();

            var settings = config.Get<ApplicationSettings>();

            services.AddSingleton<ISettingsService>(_ => new SettingsService(settings));
        }
    }
}
