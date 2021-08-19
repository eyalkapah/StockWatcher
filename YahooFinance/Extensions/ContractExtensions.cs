using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YahooFinance.Contracts;
using YahooFinance.Models;

namespace YahooFinance.Extensions
{
    public static class ContractExtensions
    {
        public static List<FormattedQuote> ToFormattedQuote(this HistoricalData historicalData)
        {
            var timestamps = historicalData.Chart.Result[0].Timestamp.ToList();

            var close = historicalData.Chart.Result[0].Indicators.Quote[0].Close;
            var open = historicalData.Chart.Result[0].Indicators.Quote[0].Open;
            var high = historicalData.Chart.Result[0].Indicators.Quote[0].High;
            var low = historicalData.Chart.Result[0].Indicators.Quote[0].Low;
            var volume = historicalData.Chart.Result[0].Indicators.Quote[0].Volume;

            var count = timestamps.Count;

            if (close.Length != count ||
                open.Length != count ||
                high.Length != count ||
                low.Length != count ||
                volume.Length != count)
            {
                throw new Exception("Inconsistent number of values");
            }

            var quotes = new List<FormattedQuote>();

            for (var i = 0; i < count; i++)
            {
                quotes.Add(new FormattedQuote
                {
                    TimeStamp = timestamps[i],
                    Close = close[i],
                    Open = open[i],
                    Low = low[i],
                    High = high[i],
                    Volume = volume[i]
                });
            }

            return quotes;
        }
    }
}
