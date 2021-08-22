using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace YahooFinance.Contracts
{
    public class SummaryDetails
    {
        [JsonPropertyName("quoteSummary")]
        public QuoteSummaryDetails QuoteSummary { get; set; }
    }

    public class QuoteSummaryDetails
    {
        [JsonPropertyName("result")] 
        public SummaryDetailResult[] result { get; set; }

        [JsonPropertyName("error")] 
        public object error { get; set; }
    }

    public class SummaryDetailResult
    {
        [JsonPropertyName("summaryDetail")]
        public SummaryDetail SummaryDetail { get; set; }
    }

    public class PreviousClose
    {
        [JsonPropertyName("raw")]
        public float Raw { get; set; }

        [JsonPropertyName("fmt")]
        public string Fmt { get; set; }
    }

    public class SummaryDetail
    {
        [JsonPropertyName("previousClose")]
        public PreviousClose PreviousClose { get; set; }
    }



}
