using Microsoft.Extensions.DependencyInjection;
using StockWatcher.Services.Interfaces;
using StockWatcher.Services.Services;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.Configurations
{
    public static class Configuration
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            return services.AddSingleton<ITextService, TextService>();

        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            return services.AddScoped<MainWindowViewModel>();
        }
    }
}
