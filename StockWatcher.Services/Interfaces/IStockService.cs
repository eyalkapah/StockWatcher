using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockWatcher.Models.Models.Models;

namespace StockWatcher.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<string>> GetUserStocks();
        Task<bool> AddStockAsync(string ticker);
        Task<IOrderedEnumerable<FormattedQuote>> GetHistoricalDataAsync(string symbol, int numOfDays);
        Task<FormattedHistoricalData> GetHistoricalDataAsync(string symbol);
        Task<bool> DeleteStockAsync(string ticker);
    }
}