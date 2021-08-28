using System;
using System.Threading.Tasks;
using YahooFinance.Contracts;
using YahooFinance.Enums;

namespace StockWatcher.Services.Interfaces
{
    public interface IDataProviderService
    {
        Task<HistoricalData> GetHistoricalDataAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            Interval frequency,
            bool includePrePost);

        Task<Profile> GetGeneralInformationAsync(string symbol);

        Task<HistoricalData> GetHistoricalDataAsync(string symbol);
    }
}