using Microsoft.Extensions.DependencyInjection;
using StockWatcher.Models;
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
                .AddSingleton<INavigationService, NavigationService>();

        }

        public static void ConfigureSystemSettings(this IServiceCollection services, ApplicationSettings settings)
        {
            services.AddSingleton<ISettingsService>(_ => new SettingsService(settings));
        }
    }
}
