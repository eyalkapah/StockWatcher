using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using StockWatcher.Services.Interfaces;
using YahooFinance;
using YahooFinance.Contracts;
using YahooFinance.Enums;
using YahooFinance.Extensions;
using YahooFinance.Helpers;

namespace StockWatcher.Services.Services
{
    public class YahooService : IDataProviderService
    {
        private readonly YahooClient _client;

        public YahooService()
        {
            _client = new YahooClient();
        }

        public async Task<HistoricalData> GetHistoricalDataAsync(string symbol, int numOfDays)
        {
            var result = await GetHistoricalDataAsync(
                symbol, 
                DateTime.Now.AddDays(-2 * numOfDays),
                DateTime.Now, 
                Interval.OneDay, 
                true);

            return result;
        }

        public async Task<HistoricalData> GetHistoricalDataAsync(
            string symbol,
            DateTime startTime,
            DateTime endTime,
            Interval frequency,
            bool includePrePost)
        {
            var yStartTime = startTime.ToUnixTimeSeconds();
            var yEndTimeEpoch = endTime.ToUnixTimeSeconds();
            var yInterval = frequency.GetIntervalString();

            var url = $"{symbol}" +
                      $"?symbol={symbol}" +
                      $"&period1={yStartTime}" +
                      $"&period2={yEndTimeEpoch}" +
                      $"&interval={yInterval}";

            var response = await _client.HttpGetClientYahoo(url);

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<HistoricalData>(json);

            return data;
        }

        public async Task<Profile> GetGeneralInformationAsync(string symbol)
        {
            var modules = new List<string> { "summaryProfile,price" };

            var modulesString = string.Join(",", modules);

            var url = $"{symbol}?modules={modulesString}";

            var response = await _client.GetV10Client(url);

            var json = await response.Content.ReadAsStringAsync();

            var profile = JsonSerializer.Deserialize<Profile>(json);

            return profile;
        }

        public async Task<HistoricalData> GetHistoricalDataAsync(string symbol)
        {
            var url = $"{symbol}?symbol={symbol}";

            var response = await _client.HttpGetClientYahoo(url);

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<HistoricalData>(json);

            return data;
        }
    }
}
