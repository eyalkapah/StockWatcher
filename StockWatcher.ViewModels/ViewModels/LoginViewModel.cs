using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace StockWatcher.ViewModels.ViewModels
{
    public class LoginViewModel : ObservableObject
    {
        private string _title;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public LoginViewModel()
        {
            Title = "Login title";
        }
    }
}
