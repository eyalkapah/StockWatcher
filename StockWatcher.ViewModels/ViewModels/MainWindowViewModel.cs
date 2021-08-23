using FancyCandles;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using StockWatcher.Models.Models;
using StockWatcher.Models.Models.CandleChart;
using StockWatcher.Models.Models.Models;
using StockWatcher.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

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
            set
            {
                if (_selectedStock != value)
                {
                    _selectedStock = value;

                    SelectedStockChanged(value);

                    OnPropertyChanged();
                }
            }
        }

        public CandlesSource CandlesSource { get; set; }

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

        private async void SelectedStockChanged(StockViewModel selectedStock)
        {
            CandlesSource.Clear();

            if (selectedStock == null)
                return;

            await PopulateQuotesAsync(selectedStock);

            await PopulateGeneralInformation(selectedStock);
        }

        private async Task PopulateGeneralInformation(StockViewModel selectedStock)
        {
            var generalInformation = await _stockService.GetStockGeneralInformationAsync(selectedStock.Ticker);

            selectedStock.GeneralInformation = generalInformation;
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
            CandlesSource = new CandlesSource(TimeFrame.M1);

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
                    var generalInformation = await _stockService.GetStockGeneralInformationAsync(stockViewModel.Ticker);

                    stockViewModel.GeneralInformation = generalInformation;

                    //var result = await _stockService.GetHistoricalDataAsync(stockViewModel.Ticker);

                    //stockViewModel.Last = result.Last;
                    //stockViewModel.Change = result.Change;
                    //stockViewModel.ChangePercentage = result.ChangeP;
                    //stockViewModel.Quotes = result.Quotes;
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

                    var viewModel = new StockViewModel(Ticker);
                    //{
                    //    Last = result.Last,
                    //    Change = result.Change,
                    //    ChangePercentage = result.ChangeP
                    //};

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
