using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace StockWatcher.Models.Models
{
    public class WatchListItem : ObservableObject
    {
        private decimal _change;

        private decimal _changeP;

        private decimal _last;
        private string _symbol;

        public string Symbol
        {
            get => _symbol;
            set => SetProperty(ref _symbol, value);
        }

        public decimal Last
        {
            get => _last;
            set => SetProperty(ref _last, value);
        }

        public decimal Change
        {
            get => _change;
            set => SetProperty(ref _change, value);
        }

        public decimal ChangeP
        {
            get => _changeP;
            set => SetProperty(ref _changeP, value);
        }
    }
}