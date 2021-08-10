using Microsoft.Extensions.DependencyInjection;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.Configurations
{
    public static class ViewModelsInstaller
    {
        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            return services.AddScoped<MainWindowViewModel>()
                .AddScoped<LoginViewModel>()
                .AddScoped<CreateAccountViewModel>();
        }
    }
}
