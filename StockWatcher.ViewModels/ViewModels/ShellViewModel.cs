using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using StockWatcher.Models.Enums;
using StockWatcher.Models.Messages;
using StockWatcher.Services.Interfaces;
using System.Windows.Input;

namespace StockWatcher.ViewModels.ViewModels
{
    public class ShellViewModel : ObservableObject
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly INavigationService _navigationService;
        private readonly IThemeService _themeService;
        private string _title;

        public ICommand ExitCommand { get; set; }
        public ICommand LogOutCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SetThemeCommand { get; set; }

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

        private bool _isLightThemeEnabled;

        public bool IsLightThemeEnabled
        {
            get => _isLightThemeEnabled;
            set => SetProperty(ref _isLightThemeEnabled, value);
        }

        private bool _isDarkThemeEnabled;

        public bool IsDarkThemeEnabled
        {
            get => _isDarkThemeEnabled;
            set => SetProperty(ref _isDarkThemeEnabled, value);
        }

        // C'tor
        //
        public ShellViewModel(IAuthenticationService authenticationService, INavigationService navigationService,
            ILogService logService, IThemeService themeService)
        {
            _authenticationService = authenticationService;
            _navigationService = navigationService;
            _themeService = themeService;

            Title = "Stock Watcher";

            ExitCommand = new RelayCommand(Exit);
            LogOutCommand = new RelayCommand(LogOut);
            RefreshCommand = new RelayCommand(Refresh);
            SetThemeCommand = new RelayCommand<Themes>(SetTheme);

            authenticationService.AuthenticationStatusChanged += AuthenticationStatusChanged;

            logService.Verbose("Application started.");

            IsLightThemeEnabled = true;
        }

        private void SetTheme(Themes theme)
        {
            _themeService.SetTheme(theme);

            IsLightThemeEnabled = theme == Themes.Light;
            IsDarkThemeEnabled = theme == Themes.Dark;
        }

        private static void Refresh()
        {
            WeakReferenceMessenger.Default.Send(new RefreshMessage(null));
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
