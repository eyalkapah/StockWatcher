using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.ViewModels.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public MainWindowViewModel()
        {
            Title = "Set from view model";
        }
    }
}
