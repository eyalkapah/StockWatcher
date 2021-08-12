using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using StockWatcher.ViewModels.ViewModels;

namespace StockWatcher.Pages
{
    /// <summary>
    /// Interaction logic for CreateAccountPage.xaml
    /// </summary>
    public partial class CreateAccountPage : Page
    {
        public CreateAccountViewModel ViewModel => DataContext as CreateAccountViewModel;
        public CreateAccountPage()
        {
            InitializeComponent();

            //PasswordBox.PasswordChanged += PasswordBoxOnPasswordChanged;
            //PasswordConfirmationBox.PasswordChanged += PasswordConfirmationBoxOnPasswordChanged;
        }

        private void PasswordConfirmationBoxOnPasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = e.OriginalSource as PasswordBox;

            ViewModel.Account.Password = passwordBox?.Password;
        }

        private void PasswordBoxOnPasswordChanged(object sender, RoutedEventArgs e)
        {
            SetPassword(e);
        }

        private void SetPassword(RoutedEventArgs e)
        {
            var passwordBox = e.OriginalSource as PasswordBox;

            ViewModel.Account.PasswordConfirmation = passwordBox?.Password;
        }
    }
}
