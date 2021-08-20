using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Input;
using StockWatcher.Models.Models;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.ViewModels.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IStockService _stockService;
        public ObservableCollection<WatchListItem> WatchList { get; set; }

        public RelayCommand AddTickerCommand { get; }

        private string _ticker;

        public string Ticker
        {
            get => _ticker;
            set
            {
                SetProperty(ref _ticker, value.ToUpper());
                OnPropertyChanged(nameof(CanAddTicker));
            }
        }

        public bool CanAddTicker => !string.IsNullOrWhiteSpace(Ticker);

        public ObservableCollection<string> Tickers { get; }
      

        public MainWindowViewModel(IStockService stockService)
        {
            _stockService = stockService;

            Tickers = new ObservableCollection<string>();

            AddTickerCommand = new RelayCommand(AddTickerAsync);


            Init();
        }

        private async void Init()
        {
            WatchList = new ObservableCollection<WatchListItem>();

            var stocks = await _stockService.GetUserStocks();

            if (stocks == null)
                return;

            foreach (var stock in stocks)
            {
                Tickers.Add(stock);
            }
        }

        private async void AddTickerAsync()
        {
            if (Tickers.Contains(Ticker))
                return;

            Tickers.Add(Ticker);

            var success = await _stockService.AddStockAsync(Ticker);

            if (!success)
            {

            }
            else
            {
                
            }

        }
    }
}
