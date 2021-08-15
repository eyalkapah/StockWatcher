using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using StockWatcher.Common;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.ViewModels.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;

        private string _errorMessage;
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand SignInCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }
        public string Password { get; set; }

        // C'tor
        //
        public LoginViewModel(INavigationService navigationService, IAuthenticationService authenticationService)
        {
            _navigationService = navigationService;
            _authenticationService = authenticationService;

            SignInCommand = new RelayCommand(SignIn);
            CreateAccountCommand = new RelayCommand(CreateAccount);
        }

        private void CreateAccount()
        {
            _navigationService.NavigateToCreateAccount();
        }

        private async void SignIn()
        {
            var result = await _authenticationService.AuthenticateAsync(Username, Password);

            if (!result)
            {
                ErrorMessage = ResourceKeys.IncorrectUsernameOrPassword;
            }
            else
            {
                _navigationService.NavigateToMain();
            }
        }
    }
}