using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatcher.Services.Interfaces
{
    public interface IStockService
    {
        Task<IEnumerable<string>> GetUserStocks();
        Task<bool> AddStockAsync(string ticker);
    }
}