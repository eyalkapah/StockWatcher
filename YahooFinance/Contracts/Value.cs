using System.Text.Json.Serialization;

namespace YahooFinance.Contracts
{
    public class Value
    {
        [JsonPropertyName("raw")]
        public float Raw { get; set; }

        [JsonPropertyName("fmt")]
        public string Fmt { get; set; }

        [JsonPropertyName("longFmt")]
        public string LongFmt { get; set; }
    }

    //public class ShortValue
    //{
    //    [JsonPropertyName("raw")]
    //    public float Raw { get; set; }

    //    [JsonPropertyName("fmt")]
    //    public string Fmt { get; set; }
    //}
}
