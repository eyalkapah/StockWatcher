using FancyCandles;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using StockWatcher.Models.Models;
using StockWatcher.Models.Models.CandleChart;
using StockWatcher.Models.Models.Models;
using StockWatcher.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using StockWatcher.Models.Enums;
using StockWatcher.Models.Messages;
using StockWatcher.Models.Models.Models.ServiceProvidersEntities;

namespace StockWatcher.ViewModels.ViewModels
{
    public class MainWindowViewModel : ObservableObject
    {
        private readonly IStockService _stockService;
        private string _ticker;
        private StockViewModel _selectedStock;

        public CandlesSource CandlesSource { get; set; }

        public ICommand RemoveStockCommand { get; set; }
        public ICommand AddTickerCommand { get; }

        public ObservableCollection<WatchListItem> WatchList { get; set; }

        public bool CanAddTicker => !string.IsNullOrWhiteSpace(Ticker);

        public ObservableCollection<StockViewModel> Tickers { get; }

        public StockViewModel SelectedStock
        {
            get => _selectedStock;
            set
            {
                if (_selectedStock == value) 
                    return;
                
                _selectedStock = value;

                SelectedStockChanged(value);

                OnPropertyChanged();
            }
        }

        public string Ticker
        {
            get => _ticker;
            set
            {
                SetProperty(ref _ticker, value.ToUpper());
                OnPropertyChanged(nameof(CanAddTicker));
            }
        }


        // C'tor
        //
        public MainWindowViewModel(IStockService stockService)
        {
            _stockService = stockService;

            Tickers = new ObservableCollection<StockViewModel>();

            AddTickerCommand = new RelayCommand(AddTickerAsync);
            RemoveStockCommand = new RelayCommand(RemoveStock);

            WeakReferenceMessenger.Default.Register<RefreshMessage>(this, RefreshHandler);

            Init();
        }

        private async void Init()
        {
            WatchList = new ObservableCollection<WatchListItem>();
            CandlesSource = new CandlesSource(TimeFrame.M1);

            var stocks = await _stockService.GetUserStocks();

            if (stocks == null)
                return;

            stocks.ToList().ForEach(ticker => Tickers.Add(new StockViewModel(ticker)));

            foreach (var stockViewModel in Tickers)
            {
                await PopulateGeneralInformation(stockViewModel);
            }

            UpdateStatusBar(DateTime.Now.ToString(CultureInfo.CurrentCulture));
        }

        

        private async void SelectedStockChanged(StockViewModel selectedStock)
        {
            CandlesSource.Clear();

            if (selectedStock == null)
                return;

            await PopulateQuotesAsync(selectedStock);

            await PopulateGeneralInformation(selectedStock);
        }

        private async void RefreshHandler(object recipient, RefreshMessage message)
        {
            await RefreshAsync();
        }

        public async Task RefreshAsync()
        {
            UpdateStatusBar("Refreshing...");

            foreach (var stockViewModel in Tickers)
            {
                await PopulateGeneralInformation(stockViewModel);
            }

            if (SelectedStock != null)
            {
                await PopulateQuotesAsync(SelectedStock);
            }

            UpdateStatusBar(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        }

        private async Task PopulateQuotesAsync(StockViewModel selectedStock)
        {
            var data = await _stockService.GetHistoricalDataAsync(selectedStock.Ticker);

            if (data == null)
                return;

            selectedStock.Quotes = data.Quotes;

            FormattedQuote lastQuote = null;

            foreach (var q in selectedStock.Quotes)
            {
                var isValid = q.Open != null && q.Close != null && q.Low != null &&
                              q.High != null && q.Volume != null;

                if (lastQuote != null)
                    isValid = lastQuote.TimeStamp < q.TimeStamp && isValid;

                if (!isValid)
                    continue;

                CandlesSource.Add(new Candle(q.StartTime, q.Open.Value, q.High.Value, q.Low.Value, q.Close.Value,
                    q.Volume.Value));

                lastQuote = q;
            }
        }

        private async Task PopulateGeneralInformation(StockViewModel stockViewModel)
        {
            try
            {
                stockViewModel.GeneralInformation = await _stockService.GetStockGeneralInformationAsync(stockViewModel.Ticker);
            }
            catch (Exception e)
            {
                Debug.Assert(false, $"Failed to populate general information: {e}");
            }
        }

        private async void AddTickerAsync()
        {
            if (Tickers.Any(t => t.Ticker.Equals(Ticker)))
                return;

            var success = await _stockService.AddStockAsync(Ticker);

            if (success)
            {
                try
                {
                    var viewModel = new StockViewModel(Ticker);

                    Tickers.Add(viewModel);

                    SelectedStock = viewModel;

                    await PopulateQuotesAsync(SelectedStock);

                    await PopulateGeneralInformation(SelectedStock);

                    Ticker = string.Empty;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                // Show error
            }
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
                // Show error
            }
        }

        private static void UpdateStatusBar(string message)
        {
            WeakReferenceMessenger.Default.Send(new StatusBarMessage(new StatusBarMessageInput
            {
                StatusBarMessageType = StatusBarMessageType.Sync,
                Message = $"Sync time: {message}"
            }));
        }
    }
}
