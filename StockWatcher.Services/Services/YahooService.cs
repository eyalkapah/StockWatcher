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

        //public async Task<IEnumerable<Price>> GetHistoricalDataAsync(string[] symbols, int numOfDays)
        //{
        //    var list = new List<Price>();

        //    foreach (var symbol in symbols)
        //    {
        //        var entries = await GetHistoricalDataAsync(symbol, numOfDays);

        //        list.AddRange(entries);
        //    }

        //    return list;
        //}

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

            //var url =
            //    $"?frequency={yfFrequency}" +
            //    "&filter=history" +
            //    $"&period1={yfStartTime}" +
            //    $"&period2={yfEndTimeEpoch}" +
            //    $"&symbol={symbol}";

            var response = await _client.HttpGetClientYahoo(url);

            var json = await response.Content.ReadAsStringAsync();

            var data = JsonSerializer.Deserialize<HistoricalData>(json);

            return data;
            //return contract.GetHistoricalData();
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

        public async Task<SummaryDetails> GetSummaryDetailsAsync(string symbol)
        {
            var modules = new List<string> { "summaryDetail" };

            var modulesString = string.Join(",", modules);

            var url = $"{symbol}?modules={modulesString}";

            var response = await _client.GetV10Client(url);

            var json = await response.Content.ReadAsStringAsync();

            var summaryDetails = JsonSerializer.Deserialize<SummaryDetails>(json);

            return summaryDetails;
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
