﻿using System.Threading.Tasks;
using StockWatcher.Models;
using StockWatcher.Models.Models.Response;

namespace StockWatcher.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<IResponse> RegisterAsync(Account account);
    }
}
