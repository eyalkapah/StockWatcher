using System;
using StockWatcher.Common;
using StockWatcher.Models.Exceptions;
using StockWatcher.Models.Models.DbResponse;
using StockWatcher.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWatcher.Models.Extensions;
using StockWatcher.Models.Factories.Yahoo;
using StockWatcher.Models.Models.Models;
using YahooFinance;
using YahooFinance.Contracts;
using YahooFinance.Enums;
using YahooFinance.Extensions;

namespace StockWatcher.Services.Services
{
    public class StockService : IStockService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDbService _dbService;
        private readonly IYahooService _yahooService;

        public StockService(IAuthenticationService authenticationService, IDbService dbService, IYahooService yahooService)
        {
            _authenticationService = authenticationService;
            _dbService = dbService;
            _yahooService = yahooService;
        }

        public async Task<IEnumerable<string>> GetUserStocks()
        {
            var authenticatedUser = _authenticationService.GetAuthenticatedUser();

            if (authenticatedUser == null)
            {
                throw new UnauthenticatedUserException();
            }

            var response = await _dbService.QueryAsync<string, dynamic>(StoredProcedures.UserStocksGetStocksByUserId,
                new { UserId = authenticatedUser.Id});

            if (response is DbErrorResponse errorResponse)
                return default;

            var successResponse = response as DbSuccessResponse<IEnumerable<string>>;

            return successResponse?.Result;
        }

        public async Task<bool> AddStockAsync(string ticker)
        {
            var authenticatedUser = _authenticationService.GetAuthenticatedUser();

            if (authenticatedUser == null)
            {
                throw new UnauthenticatedUserException();
            }

            var response = await _dbService.ExecuteAsync(StoredProcedures.UserStocksInsertStock, new
            {
                UserId = authenticatedUser.Id,
                Ticker = ticker
            });

            if (response is DbErrorResponse errorResponse)
                return false;

            return true;
        }

        public async Task<bool> DeleteStockAsync(string ticker)
        {
            
            var authenticatedUser = _authenticationService.GetAuthenticatedUser();

            if (authenticatedUser == null)
            {
                throw new UnauthenticatedUserException();
            }

            var response = await _dbService.ExecuteAsync(StoredProcedures.UserStocksDeleteStock, new
            {
                UserId = authenticatedUser.Id,
                Ticker = ticker
            });

            if (response is DbErrorResponse errorResponse)
                return false;

            return true;
        }

        public async Task<FormattedGeneralInformation> GetStockGeneralInformationAsync(string symbol)
        {
            var result = await _yahooService.GetGeneralInformationAsync(symbol);

            var summaryProfile = result.QuoteSummary.Result[0].SummaryProfile;
            var price = result.QuoteSummary.Result[0].Price;

            var generalInformation = YahooFactory.BuildGeneralInformation(summaryProfile, price);
            
            if (generalInformation == null)
                throw new Exception("Failed to get general information");

            return generalInformation;
        }


        public async Task<FormattedHistoricalData> GetHistoricalDataAsync(string symbol)
        {
            var data = await _yahooService.GetHistoricalDataAsync(symbol);

            var formattedDetails = new FormattedHistoricalData
            {
                Last = (decimal)data.Chart.Result[0].Meta.RegularMarketPrice,
                PreviousClose = (decimal)data.Chart.Result[0].Meta.ChartPreviousClose,
                Quotes = data.ToFormattedQuote()
            };
            
            return formattedDetails;
        }

        public async Task<IOrderedEnumerable<FormattedQuote>> GetHistoricalDataAsync(string symbol, int numOfDays)
        {
            var result = await _yahooService.GetHistoricalDataAsync(
                symbol, 
                DateTime.Now.AddDays(-2 * numOfDays),
                DateTime.Now, 
                Interval.OneDay, 
                true);

            return result.ToFormattedQuote().TakeLastOf(numOfDays).OrderBy(c => c.TimeStamp);
        }
    }
}
