using System.Windows.Controls;
using StockWatcher.Pages;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.Services
{
    public class NavigationService : INavigationService
    {
        private Frame _frame;

        public void SetFrame(object frame)
        {
            _frame = frame as Frame;
        }

        public void NavigateToLogin()
        {
            var loginPage = new LoginPage();


            if (_frame.Navigate(loginPage))
            {

            }
        }
    }
}
