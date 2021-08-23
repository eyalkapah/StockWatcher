using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using StockWatcher.Models.Messages;
using System;
using System.Windows.Input;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.ViewModels.ViewModels
{
    public class ShellViewModel : ObservableObject
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;
        private string _title;

        public ICommand ExitCommand { get; set; }
        public ICommand LogOutCommand { get; set; }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private bool _isLoggedIn;

        public bool IsLoggedIn
        {
            get => _isLoggedIn;
            set => SetProperty(ref _isLoggedIn, value);
        }

        public ShellViewModel(IAuthenticationService authenticationService, INavigationService navigationService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;

            Title = "Stock Watcher";

            ExitCommand = new RelayCommand(Exit);
            LogOutCommand = new RelayCommand(LogOut);

            authenticationService.AuthenticationStatusChanged += AuthenticationStatusChanged;
        }

        private void AuthenticationStatusChanged(object sender, bool isAuthenticated)
        {
            IsLoggedIn = isAuthenticated;
        }

        private void LogOut()
        {
            _authenticationService.LogOut();

            _navigationService.NavigateToLogin();
        }

        private static void Exit()
        {
            WeakReferenceMessenger.Default.Send(new ShutdownMessage(true));
        }
    }
}
