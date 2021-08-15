using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockWatcher.Services.Interfaces
{
    public interface IDbService
    {
        Task ExecuteAsync<T>(string storedProcedure, T parameters);

        Task<List<T>> QueryAsync<T, U>(string storedProcedure, U parameters);
    }
}
