using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows.Input;

namespace StockWatcher.ViewModels.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
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
        public LoginViewModel()
        {
            SignInCommand = new RelayCommand(SignIn);
            CreateAccountCommand = new RelayCommand(CreateAccount);
        }

        private void CreateAccount()
        {
            throw new NotImplementedException();
        }

        private void SignIn()
        {
            throw new NotImplementedException();
        }
    }
}
