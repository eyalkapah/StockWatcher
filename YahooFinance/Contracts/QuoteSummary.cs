using System.Text.Json.Serialization;

namespace YahooFinance.Contracts
{
    public class Profile
    {
        [JsonPropertyName("quoteSummary")] public QuoteSummary QuoteSummary { get; set; }
    }

    public class QuoteSummary
    {
        [JsonPropertyName("result")] public Result[] Result { get; set; }

        [JsonPropertyName("error")] public object Error { get; set; }
    }

    public class Result
    {
        [JsonPropertyName("price")] public Price Price { get; set; }

        [JsonPropertyName("summaryProfile")] public SummaryProfile SummaryProfile { get; set; }
    }

    public class Price
    {
        [JsonPropertyName("maxAge")] public int MaxAge { get; set; }

        [JsonPropertyName("preMarketChange")] public Value PreMarketChange { get; set; }

        [JsonPropertyName("preMarketPrice")] public Value PreMarketPrice { get; set; }

        [JsonPropertyName("preMarketSource")] public string PreMarketSource { get; set; }

        [JsonPropertyName("postMarketChangePercent")]
        public Value PostMarketChangePercent { get; set; }

        [JsonPropertyName("postMarketChange")] public Value PostMarketChange { get; set; }

        [JsonPropertyName("postMarketTime")] public int PostMarketTime { get; set; }
        [JsonPropertyName("postMarketPrice")] public Value PostMarketPrice { get; set; }

        [JsonPropertyName("postMarketSource")] public string PostMarketSource { get; set; }

        [JsonPropertyName("regularMarketChangePercent")]
        public Value RegularMarketChangePercent { get; set; }

        [JsonPropertyName("regularMarketChange")]
        public Value RegularMarketChange { get; set; }

        [JsonPropertyName("regularMarketTime")]
        public int RegularMarketTime { get; set; }

        [JsonPropertyName("priceHint")] public Value PriceHint { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public Value RegularMarketPrice { get; set; }

        [JsonPropertyName("regularMarketDayHigh")]
        public Value RegularMarketDayHigh { get; set; }

        [JsonPropertyName("regularMarketDayLow")]
        public Value RegularMarketDayLow { get; set; }

        [JsonPropertyName("regularMarketVolume")]
        public Value RegularMarketVolume { get; set; }

        [JsonPropertyName("averageDailyVolume10Day")]
        public Value AverageDailyVolume10Day { get; set; }

        [JsonPropertyName("averageDailyVolume3Month")]
        public AverageDailyVolume3Month AverageDailyVolume3Month { get; set; }

        [JsonPropertyName("regularMarketPreviousClose")]
        public Value RegularMarketPreviousClose { get; set; }

        [JsonPropertyName("regularMarketSource")]
        public string RegularMarketSource { get; set; }

        [JsonPropertyName("regularMarketOpen")]
        public Value RegularMarketOpen { get; set; }

        [JsonPropertyName("strikePrice")] public StrikePrice StrikePrice { get; set; }
        [JsonPropertyName("openInterest")] public OpenInterest OpenInterest { get; set; }
        [JsonPropertyName("exchange")] public string Exchange { get; set; }
        [JsonPropertyName("exchangeName")] public string ExchangeName { get; set; }

        [JsonPropertyName("exchangeDataDelayedBy")]
        public int ExchangeDataDelayedBy { get; set; }

        [JsonPropertyName("marketState")] public string MarketState { get; set; }
        [JsonPropertyName("quoteType")] public string QuoteType { get; set; }
        [JsonPropertyName("symbol")] public string Symbol { get; set; }
        [JsonPropertyName("underlyingSymbol")] public object UnderlyingSymbol { get; set; }
        [JsonPropertyName("shortName")] public string ShortName { get; set; }
        [JsonPropertyName("longName")] public string LongName { get; set; }
        [JsonPropertyName("currency")] public string Currency { get; set; }
        [JsonPropertyName("quoteSourceName")] public string QuoteSourceName { get; set; }
        [JsonPropertyName("currencySymbol")] public string CurrencySymbol { get; set; }
        [JsonPropertyName("fromCurrency")] public object FromCurrency { get; set; }
        [JsonPropertyName("toCurrency")] public object ToCurrency { get; set; }
        [JsonPropertyName("lastMarket")] public object LastMarket { get; set; }
        [JsonPropertyName("volume24Hr")] public Volume24hr Volume24Hr { get; set; }

        [JsonPropertyName("volumeAllCurrencies")]
        public VolumeAllCurrencies VolumeAllCurrencies { get; set; }

        [JsonPropertyName("circulatingSupply")]
        public CirculatingSupply CirculatingSupply { get; set; }

        [JsonPropertyName("marketCap")] public Value MarketCap { get; set; }
    }

    public class AverageDailyVolume3Month
    {
    }


    public class StrikePrice
    {
    }

    public class OpenInterest
    {
    }

    public class Volume24hr
    {
    }

    public class VolumeAllCurrencies
    {
    }

    public class CirculatingSupply
    {
    }


    public class SummaryProfile
    {
        [JsonPropertyName("address1")] public string Address1 { get; set; }

        [JsonPropertyName("city")] public string City { get; set; }

        [JsonPropertyName("state")] public string State { get; set; }

        [JsonPropertyName("zip")] public string Zip { get; set; }

        [JsonPropertyName("country")] public string Country { get; set; }

        [JsonPropertyName("phone")] public string Phone { get; set; }

        [JsonPropertyName("website")] public string Website { get; set; }

        [JsonPropertyName("industry")] public string Industry { get; set; }

        [JsonPropertyName("sector")] public string Sector { get; set; }

        [JsonPropertyName("longBusinessSummary")]
        public string LongBusinessSummary { get; set; }

        [JsonPropertyName("fullTimeEmployees")]
        public int FullTimeEmployees { get; set; }

        [JsonPropertyName("companyOfficers")] public object[] CompanyOfficers { get; set; }

        [JsonPropertyName("maxAge")] public int MaxAge { get; set; }
    }
}