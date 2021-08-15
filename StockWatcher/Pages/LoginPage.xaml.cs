using System.Windows;
using System.Windows.Controls;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as LoginViewModel;

            if (viewModel == null)
                return;

            var passwordBox = e.OriginalSource as PasswordBox;

            viewModel.Password = passwordBox?.Password;
        }
    }
}
