using System.Collections.Generic;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using StockWatcher.Models.Models.Models;
using StockWatcher.Models.Models.Models.ServiceProvidersEntities;

namespace StockWatcher.ViewModels.ViewModels
{
    public class StockViewModel : ObservableObject
    {
        //private decimal _change;

        //private decimal _changePercentage;

        //private decimal _last;
        private string _ticker;

        public StockViewModel(string ticker)
        {
            Ticker = ticker;

            Quotes = new List<FormattedQuote>();
        }

        public string Ticker
        {
            get => _ticker;
            set => SetProperty(ref _ticker, value);
        }

        //public decimal Last
        //{
        //    get => _last;
        //    set => SetProperty(ref _last, value);
        //}

        //public decimal Change
        //{
        //    get => _change;
        //    set => SetProperty(ref _change, value);
        //}

        //public decimal ChangePercentage
        //{
        //    get => _changePercentage;
        //    set => SetProperty(ref _changePercentage, value);
        //}

        private List<FormattedQuote> _quotes;

        public List<FormattedQuote> Quotes
        {
            get => _quotes;
            set => SetProperty(ref _quotes, value);
        }

        private FormattedGeneralInformation _generalInformation;

        public FormattedGeneralInformation GeneralInformation
        {
            get => _generalInformation;
            set => SetProperty(ref _generalInformation, value);
        }
    }
}