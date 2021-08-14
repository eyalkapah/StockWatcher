using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockWatcher.Models;
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
            return services.AddSingleton<ITextService, TextService>()
                .AddSingleton<INavigationService, NavigationService>()
                .AddSingleton<IAuthenticationService, AuthenticationService>();

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
