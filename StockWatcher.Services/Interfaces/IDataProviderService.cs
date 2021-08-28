using System;
using System.Threading.Tasks;
using YahooFinance.Contracts;
using YahooFinance.Enums;

namespace StockWatcher.Services.Interfaces
{
    public interface IDataProviderService
    {
        //Task<IEnumerable<Price>> GetHistoricalDataAsync(string[] symbols, int numOfDays);
        Task<HistoricalData> GetHistoricalDataAsync(string symbol, int numOfDays);

        Task<HistoricalData> GetHistoricalDataAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            Interval frequency,
            bool includePrePost);

        Task<Profile> GetGeneralInformationAsync(string symbol);

        Task<SummaryDetails> GetSummaryDetailsAsync(string symbol);

        Task<HistoricalData> GetHistoricalDataAsync(string symbol);
    }
}