using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace StockWatcher.ViewModels.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel Main => Ioc.Default.GetService<MainWindowViewModel>();
    }
}
