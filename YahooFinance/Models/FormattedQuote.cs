using System;
using YahooFinance.Extensions;

namespace YahooFinance.Models
{
    public class FormattedQuote
    {
        public long TimeStamp { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public int Volume { get; set; }
        public float Open { get; set; }

        public DateTime StartTime => DateTimeExtensions.FromUnixTimeSeconds(TimeStamp);
    }
}
