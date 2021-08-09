using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.ViewModels.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private string _username;

        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        public ICommand SignInCommand { get; set; }
        public ICommand CreateAccountCommand { get; set; }

        // C'tor
        //
        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            SignInCommand = new RelayCommand(SignIn);
            CreateAccountCommand = new RelayCommand(CreateAccount);
        }

        private void CreateAccount()
        {
            _navigationService.NavigateToCreateAccount();
        }

        private void SignIn()
        {
            throw new NotImplementedException();
        }
    }
}
