using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace StockWatcher.ViewModels.ViewModels
{
    public class ViewModelLocator
    {
        public MainWindowViewModel Main => Ioc.Default.GetService<MainWindowViewModel>();
        public LoginViewModel Login => Ioc.Default.GetService<LoginViewModel>();
        public CreateAccountViewModel CreateAccount => Ioc.Default.GetService<CreateAccountViewModel>();
        public ShellViewModel Shell => Ioc.Default.GetService<ShellViewModel>();
    }
}
