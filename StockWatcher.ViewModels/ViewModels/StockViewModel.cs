using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace StockWatcher.ViewModels.ViewModels
{
    public class StockViewModel : ObservableObject
    {
        private decimal _change;

        private decimal _changePercentage;

        private decimal _last;
        private string _ticker;

        public StockViewModel(string ticker)
        {
            Ticker = ticker;
        }

        public string Ticker
        {
            get => _ticker;
            set => SetProperty(ref _ticker, value);
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

        public decimal ChangePercentage
        {
            get => _changePercentage;
            set => SetProperty(ref _changePercentage, value);
        }
    }
}