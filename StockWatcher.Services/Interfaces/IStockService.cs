﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWatcher.Models.Models.Models;
using StockWatcher.Models.Models.Models.ServiceProvidersEntities;

namespace StockWatcher.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<string>> GetUserStocks();
        Task<bool> AddStockAsync(string ticker);
        Task<IOrderedEnumerable<FormattedQuote>> GetHistoricalDataAsync(string symbol, int numOfDays);
        Task<FormattedHistoricalData> GetHistoricalDataAsync(string symbol);
        Task<bool> DeleteStockAsync(string ticker);
        Task<FormattedGeneralInformation> GetStockGeneralInformationAsync(string symbol);
    }
}