using System.Text.Json.Serialization;

namespace YahooFinance.Contracts
{
    public class HistoricalData
    {
        [JsonPropertyName("chart")]
        public Chart Chart { get; set; }
    }

    public class Chart
    {
        [JsonPropertyName("result")]
        public ChartResult[] Result { get; set; }

        [JsonPropertyName("error")]
        public object Error { get; set; }
    }

    public class ChartResult
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("timestamp")]
        public int[] Timestamp { get; set; }

        [JsonPropertyName("indicators")]
        public Indicators Indicators { get; set; }
    }

    public class Meta
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("exchangeName")]
        public string ExchangeName { get; set; }

        [JsonPropertyName("instrumentType")]
        public string InstrumentType { get; set; }

        [JsonPropertyName("firstTradeDate")]
        public int FirstTradeDate { get; set; }

        [JsonPropertyName("regularMarketTime")]
        public int RegularMarketTime { get; set; }

        [JsonPropertyName("gmtoffset")]
        public int Gmtoffset { get; set; }

        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("exchangeTimezoneName")]
        public string ExchangeTimezoneName { get; set; }

        [JsonPropertyName("regularMarketPrice")]
        public float RegularMarketPrice { get; set; }
        
        [JsonPropertyName("chartPreviousClose")]
        public float ChartPreviousClose { get; set; }

        [JsonPropertyName("priceHint")]
        public int PriceHint { get; set; }

        [JsonPropertyName("currentTradingPeriod")]
        public CurrentTradingPeriod CurrentTradingPeriod { get; set; }

        [JsonPropertyName("dataGranularity")]
        public string DataGranularity { get; set; }

        [JsonPropertyName("range")]
        public string Range { get; set; }

        [JsonPropertyName("validRanges")]
        public string[] ValidRanges { get; set; }
    }

    public class CurrentTradingPeriod
    {
        [JsonPropertyName("pre")]
        public Pre Pre { get; set; }

        [JsonPropertyName("regular")]
        public Regular Regular { get; set; }

        [JsonPropertyName("post")]
        public Post Post { get; set; }
    }

    public class Pre
    {
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("gmtoffset")]
        public int Gmtoffset { get; set; }
    }

    public class Regular
    {
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("gmtoffset")]
        public int Gmtoffset { get; set; }
    }

    public class Post
    {
        [JsonPropertyName("timezone")]
        public string Timezone { get; set; }

        [JsonPropertyName("start")]
        public int Start { get; set; }

        [JsonPropertyName("end")]
        public int End { get; set; }

        [JsonPropertyName("gmtoffset")]
        public int Gmtoffset { get; set; }
    }

    public class Indicators
    {
        [JsonPropertyName("quote")]
        public Quote[] Quote { get; set; }

        [JsonPropertyName("adjclose")]
        public AdjClose[] Adjclose { get; set; }
    }

    public class Quote
    {
        [JsonPropertyName("high")]
        public float?[] High { get; set; }

        [JsonPropertyName("low")]
        public float?[] Low { get; set; }

        [JsonPropertyName("close")]
        public float?[] Close { get; set; }

        [JsonPropertyName("volume")]
        public int?[] Volume { get; set; }

        [JsonPropertyName("open")]
        public float?[] Open { get; set; }
    }

    public class AdjClose
    {
        [JsonPropertyName("adjclose")]
        public float[] Adjclose { get; set; }
    }

}
