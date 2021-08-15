using System.Linq;
using System.Windows.Input;
using FluentValidation.Results;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using StockWatcher.Models;
using StockWatcher.Services.Interfaces;
using StockWatcher.ViewModels.Utils;

namespace StockWatcher.ViewModels.ViewModels
{
    public class CreateAccountViewModel : ObservableObject
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;
        private Account _account;

        private string _emailErrorMessage;

        private string _firstNameErrorMessage;

        private string _lastNameErrorMessage;

        private string _passwordConfirmationErrorMessage;

        private string _passwordErrorMessage;

        public Account Account
        {
            get => _account;
            set => SetProperty(ref _account, value);
        }

        public string FirstNameErrorMessage
        {
            get => _firstNameErrorMessage;
            set => SetProperty(ref _firstNameErrorMessage, value);
        }

        public string LastNameErrorMessage
        {
            get => _lastNameErrorMessage;
            set => SetProperty(ref _lastNameErrorMessage, value);
        }

        public string EmailErrorMessage
        {
            get => _emailErrorMessage;
            set => SetProperty(ref _emailErrorMessage, value);
        }

        public string PasswordErrorMessage
        {
            get => _passwordErrorMessage;
            set => SetProperty(ref _passwordErrorMessage, value);
        }

        public string PasswordConfirmationErrorMessage
        {
            get => _passwordConfirmationErrorMessage;
            set => SetProperty(ref _passwordConfirmationErrorMessage, value);
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand NavigateToSignInPageCommand { get; set; }

        // C'tor
        //
        public CreateAccountViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;

            Account = new Account();

            RegisterCommand = new RelayCommand(Register);
            NavigateToSignInPageCommand = new RelayCommand(NavigateToSignInPage);
        }

        private void NavigateToSignInPage()
        {
            _navigationService.NavigateToLogin();
        }

        private async void Register()
        {
            var validator = new AccountValidator();

            var results = await validator.ValidateAsync(Account);

            if (results.IsValid)
            {
                FirstNameErrorMessage = string.Empty;
                LastNameErrorMessage = string.Empty;
                EmailErrorMessage = string.Empty;
                PasswordErrorMessage = string.Empty;
                PasswordConfirmationErrorMessage = string.Empty;
                ErrorMessage = string.Empty;

                var response = await _authenticationService.RegisterAsync(Account);

                if (!response.IsSuccess())
                {
                    ErrorMessage = response.Message;
                }
                else
                {
                    _navigationService.NavigateToLogin();
                }
            }
            else
            {
                FirstNameErrorMessage = GetErrorMessage(results, nameof(Account.FirstName));

                LastNameErrorMessage = GetErrorMessage(results, nameof(Account.LastName));

                EmailErrorMessage = GetErrorMessage(results, nameof(Account.Email));

                PasswordErrorMessage = GetErrorMessage(results, nameof(Account.Password));

                PasswordConfirmationErrorMessage = GetErrorMessage(results, nameof(Account.PasswordConfirmation));

                
            }
        }

        private static string GetErrorMessage(ValidationResult results, string propertyName)
        {
            return results.Errors.FirstOrDefault(c => c.PropertyName == propertyName)
                ?.ErrorMessage;
        }
    }
}