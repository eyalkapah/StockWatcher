namespace StockWatcher.Models.Models.Models
{
    public class FormattedGeneralInformation
    {
        public FormattedValue RegularMarketChangePercent { get; set; }
        public FormattedValue RegularMarketChange { get; set; }
        public FormattedValue RegularMarketPrice { get; set; }
        public FormattedValue RegularMarketDayHigh { get; set; }
        public FormattedValue RegularMarketDayLow { get; set; }
        public FormattedValue RegularMarketVolume { get; set; }
        public FormattedValue AverageDailyVolume10Day { get; set; }
        public FormattedValue RegularMarketPreviousClose { get; set; }
        public FormattedValue RegularMarketOpen { get; set; }
        public string Exchange { get; set; }
        public string ExchangeName { get; set; }
        public string MarketState { get; set; }
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public string Currency { get; set; }
        public string CurrencySymbol { get; set; }
        public FormattedValue MarketCap { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string Industry { get; set; }
        public string Sector { get; set; }
        public string Summary { get; set; }
        public int FullTimeEmployees { get; set; }
        
    }
}
