using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using YahooFinance.Contracts;
using YahooFinance.Enums;
using YahooFinance.Extensions;
using YahooFinance.Helpers;
using YahooFinance.Models;

namespace YahooFinance
{
    public class YahooService : IYahooService
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

        public async Task<IOrderedEnumerable<FormattedQuote>> GetHistoricalDataAsync(string symbol, int numOfDays)
        {
            var result = await GetHistoricalDataAsync(
                symbol, 
                DateTime.Now.AddDays(-2 * numOfDays),
                DateTime.Now, 
                Interval.OneDay, 
                true);

            return result.ToFormattedQuote().TakeLastOf(numOfDays).OrderBy(c => c.TimeStamp);
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

        public async Task<Profile> GetProfileAsync(string symbol)
        {
            var modules = new List<string> { "summaryProfile" };

            var modulesString = string.Join(",", modules);

            var url = $"{symbol}?modules={modulesString}";

            var response = await _client.GetV10Client(url);

            var json = await response.Content.ReadAsStringAsync();

            var profile = JsonSerializer.Deserialize<Profile>(json);

            return profile;
        }

        //public async Task<FundamentalData> GetFundamentalDataAsync(string symbol, bool assetProfile,
        //    bool recommendationTrend, bool cashflowStatementHistory,
        //    bool indexTrend, bool defaultKeyStatistics, bool industryTrend, bool incomeStatementHistory,
        //    bool fundOwnership, bool summaryDetail, bool insiderHolders, bool calendarEvents,
        //    bool upgradeDowngradeHistory, bool price,
        //    bool earningsTrend, bool secFilings, bool institutionOwnership, bool majorHoldersBreakdown,
        //    bool balanceSheetHistory, bool majorDirectHolders, bool esgScores,
        //    bool summaryProfile, bool netSharePurchaseActivity, bool insiderTransactions,
        //    bool incomeStatementHistoryQuarterly, bool cashflowStatementHistoryQuarterly,
        //    bool financialData)
        //{
        //    var builder = new List<string>();

        //    builder.AddModule(nameof(assetProfile), assetProfile);
        //    builder.AddModule(nameof(recommendationTrend), recommendationTrend);
        //    builder.AddModule(nameof(cashflowStatementHistory), cashflowStatementHistory);
        //    builder.AddModule(nameof(indexTrend), indexTrend);
        //    builder.AddModule(nameof(defaultKeyStatistics), defaultKeyStatistics);
        //    builder.AddModule(nameof(industryTrend), industryTrend);
        //    builder.AddModule(nameof(incomeStatementHistory), incomeStatementHistory);
        //    builder.AddModule(nameof(fundOwnership), fundOwnership);
        //    builder.AddModule(nameof(summaryDetail), summaryDetail);
        //    builder.AddModule(nameof(insiderHolders), insiderHolders);
        //    builder.AddModule(nameof(calendarEvents), calendarEvents);
        //    builder.AddModule(nameof(upgradeDowngradeHistory), upgradeDowngradeHistory);
        //    builder.AddModule(nameof(price), price);
        //    builder.AddModule(nameof(earningsTrend), earningsTrend);
        //    builder.AddModule(nameof(secFilings), secFilings);
        //    builder.AddModule(nameof(institutionOwnership), institutionOwnership);
        //    builder.AddModule(nameof(majorHoldersBreakdown), majorHoldersBreakdown);
        //    builder.AddModule(nameof(balanceSheetHistory), balanceSheetHistory);
        //    builder.AddModule(nameof(majorDirectHolders), majorDirectHolders);
        //    builder.AddModule(nameof(esgScores), esgScores);
        //    builder.AddModule(nameof(summaryProfile), summaryProfile);
        //    builder.AddModule(nameof(netSharePurchaseActivity), netSharePurchaseActivity);
        //    builder.AddModule(nameof(insiderTransactions), insiderTransactions);
        //    builder.AddModule(nameof(incomeStatementHistoryQuarterly), incomeStatementHistoryQuarterly);
        //    builder.AddModule(nameof(cashflowStatementHistoryQuarterly), cashflowStatementHistoryQuarterly);
        //    builder.AddModule(nameof(financialData), financialData);

        //    var modules = string.Join(",", builder);

        //    var url = $"{symbol}?modules={modules}";

        //    var response = await _client.GetV10Client(url);

        //    var json = await response.Content.ReadAsStringAsync();

        //    var contract = JsonSerializer.Deserialize<FundamentalDataContract>(json);

        //    return contract.GetFundamentalData();
        //}

        //public async Task<Options> GetOptionsContractAsync(string symbol, DateTime date)
        //{
        //    var url = symbol;

        //    var epochTime = decimal.MinValue;

        //    if (date > DateTime.Now.Date)
        //    {
        //        epochTime = date.ToUnixTimeSeconds();
        //    }

        //    if (epochTime != long.MinValue)
        //    {
        //        url = $"{url}?date={epochTime}";
        //    }

        //    var response = await _client.GetV7Client(url);

        //    var json = await response.Content.ReadAsStringAsync();

        //    var contract = JsonSerializer.Deserialize<OptionsContract>(json);

        //    return contract.GetOptions();
        //}
    }
}
