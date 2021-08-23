using StockWatcher.Models.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using StockWatcher.Models.Models.Models.ServiceProvidersEntities;
using YahooFinance.Contracts;

namespace StockWatcher.Models.Factories.Yahoo
{
    public static class YahooFactory
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

        public static FormattedValue Format(this Value value) => new FormattedValue
        {
            Raw = value.Raw,
            Format = value.Fmt,
            LongFormat = !string.IsNullOrWhiteSpace(value.LongFmt) ? value.LongFmt : null
        };

        public static FormattedGeneralInformation BuildGeneralInformation(SummaryProfile summaryProfile, Price price)
        {
            return new FormattedGeneralInformation
            {
                RegularMarketChangePercent = price.RegularMarketChangePercent.Format(),
                RegularMarketChange = price.RegularMarketChange.Format(),
                RegularMarketPrice = price.RegularMarketPrice.Format(),
                RegularMarketDayHigh = price.RegularMarketDayHigh.Format(),
                RegularMarketDayLow = price.RegularMarketDayLow.Format(),
                RegularMarketVolume = price.RegularMarketVolume.Format(),
                AverageDailyVolume10Day = price.AverageDailyVolume10Day.Format(),
                RegularMarketPreviousClose = price.RegularMarketPreviousClose.Format(),
                RegularMarketOpen = price.RegularMarketOpen.Format(),
                Exchange = price.Exchange,
                ExchangeName = price.ExchangeName,
                MarketState = price.MarketState,
                ShortName = price.ShortName,
                LongName = price.LongName,
                Currency = price.Currency,
                CurrencySymbol = price.CurrencySymbol,
                MarketCap = price.MarketCap.Format(),
                Address = summaryProfile.Address1,
                City = summaryProfile.City,
                State = summaryProfile.State,
                Zip = summaryProfile.Zip,
                Country = summaryProfile.Country,
                Phone = summaryProfile.Phone,
                Website = summaryProfile.Website,
                Industry = summaryProfile.Industry,
                Sector = summaryProfile.Sector,
                Summary = summaryProfile.LongBusinessSummary,
                FullTimeEmployees = summaryProfile.FullTimeEmployees
            };
        }
    }
}
