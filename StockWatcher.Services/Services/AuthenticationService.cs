using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockWatcher.Common;
using StockWatcher.Models;
using StockWatcher.Models.Database.User;
using StockWatcher.Models.Models.Response;
using StockWatcher.Services.Helpers;
using StockWatcher.Services.Interfaces;

namespace StockWatcher.Services.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IDbService _dbService;

        public AuthenticationService(IDbService dbService)
        {
            _dbService = dbService;
        }

        public async Task<IResponse> RegisterAsync(Account account)
        {
            try
            {
                var hash = Crypto.HashPassword(account.Password);

                await _dbService.ExecuteAsync(StoredProcedures.UsersInsert, new UserCreate
                {
                    Email = account.Email,
                    Password = hash,
                    FirstName = account.FirstName,
                    LastName = account.LastName
                });
            }
            catch (SqlException e)
            {
                if (e.Number == 2627)
                {
                    return new ErrorResponse("Email address already registered", 2627);
                }
            }
            catch (Exception e)
            {
                return new ErrorResponse($"Unknown error: {e.Message}", 0);
            }

            return new SuccessResponse();
        }
    }
}
