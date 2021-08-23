using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using StockWatcher.Models.Messages;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.ViewModels.ViewModels
{
    public class StatusBarViewModel : ObservableObject
    {
        private readonly IStatusBarService _statusBarService;

        private string _text;

        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value);
        }

        private string _imageSource;

        public string ImageSource
        {
            get => _imageSource;
            set => SetProperty(ref _imageSource, value);
        }

        public StatusBarViewModel(IStatusBarService statusBarService)
        {
            _statusBarService = statusBarService;

            WeakReferenceMessenger.Default.Register<StatusBarMessage>(this, StatusBarMessageReceived);
        }

        private void StatusBarMessageReceived(object recipient, StatusBarMessage message)
        {
            (Text, ImageSource) =
                _statusBarService.GetStatusBarPackage(message.Value.StatusBarMessageType, message.Value.Message);
        }
    }
}
