using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YahooFinance.Contracts;
using YahooFinance.Enums;
using YahooFinance.Models;

namespace YahooFinance
{
    public interface IYahooService
    {
        //Task<IEnumerable<Price>> GetHistoricalDataAsync(string[] symbols, int numOfDays);
        Task<IOrderedEnumerable<FormattedQuote>> GetHistoricalDataAsync(string symbol, int numOfDays);

        Task<HistoricalData> GetHistoricalDataAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            Interval frequency,
            bool includePrePost);

        Task<Profile> GetProfileAsync(string symbol);
    }
}