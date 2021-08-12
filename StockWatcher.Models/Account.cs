using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace StockWatcher.Models
{
    public class Account : ObservableObject
    {
        private string _email;

        private string _firstName;

        private string _lastName;
        private string _password;

        private string _passwordConfirmation;

        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        public string PasswordConfirmation
        {
            get => _passwordConfirmation;
            set => SetProperty(ref _passwordConfirmation, value);
        }

        public string FirstName
        {
            get => _firstName;
            set => SetProperty(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetProperty(ref _lastName, value);
        }

        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private List<string> _validationErrors;

        public List<string> ValidationErrors
        {
            get => _validationErrors;
            set => SetProperty(ref _validationErrors, value);
        }
    }
}