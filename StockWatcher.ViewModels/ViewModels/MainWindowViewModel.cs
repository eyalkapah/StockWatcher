using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
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

        public ObservableCollection<StockViewModel> Tickers { get; }

        private StockViewModel _selectedStock;

        public StockViewModel SelectedStock
        {
            get => _selectedStock;
            set => SetProperty(ref _selectedStock, value);
        }

        public ICommand RemoveStockCommand { get; set; }

        // C'tor
        //
        public MainWindowViewModel(IStockService stockService)
        {
            _stockService = stockService;

            Tickers = new ObservableCollection<StockViewModel>();

            AddTickerCommand = new RelayCommand(AddTickerAsync);
            RemoveStockCommand = new RelayCommand(RemoveStock);


            Init();
        }

        private async void RemoveStock()
        {
            if (SelectedStock == null)
                return;

            var response = await _stockService.DeleteStockAsync(SelectedStock.Ticker);

            if (response)
            {
                Tickers.Remove(SelectedStock);
            }
            else
            {
                
            }
        }

        private async void Init()
        {
            WatchList = new ObservableCollection<WatchListItem>();

            var stocks = await _stockService.GetUserStocks();

            if (stocks == null)
                return;

            foreach (var ticker in stocks)
            {
                Tickers.Add(new StockViewModel(ticker));
            }

            foreach (var stockViewModel in Tickers)
            {
                try
                {
                    var result = await _stockService.GetHistoricalDataAsync(stockViewModel.Ticker);

                    stockViewModel.Last = result.Last;
                    stockViewModel.Change = result.Change;
                    stockViewModel.ChangePercentage = result.ChangeP;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }

        private async void AddTickerAsync()
        {
            if (Tickers.Any(t => t.Ticker.Equals(Ticker)))
                return;

            var success = await _stockService.AddStockAsync(Ticker);

            if (!success)
            {
                
            }
            else
            {
                try
                {
                    var result = await _stockService.GetHistoricalDataAsync(Ticker);

                    var viewModel = new StockViewModel(Ticker)
                    {
                        Last = result.Last,
                        Change = result.Change,
                        ChangePercentage = result.ChangeP
                    };

                    Tickers.Add(viewModel);

                    Ticker = string.Empty;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
              
            }

        }
    }
}
