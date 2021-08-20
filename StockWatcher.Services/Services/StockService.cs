using StockWatcher.Common;
using StockWatcher.Models.Exceptions;
using StockWatcher.Models.Models.DbResponse;
using StockWatcher.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatcher.Services.Services
{
    public class StockService : IStockService
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDbService _dbService;

        public StockService(IAuthenticationService authenticationService, IDbService dbService)
        {
            _authenticationService = authenticationService;
            _dbService = dbService;
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
    }
}
