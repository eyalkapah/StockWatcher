using System.Collections.Generic;
using System.Threading.Tasks;
using StockWatcher.Models.Models.DbResponse;

namespace StockWatcher.Services.Interfaces
{
    public interface IDbService
    {
        Task<IDbResponse> ExecuteAsync<T>(string storedProcedure, T parameters);

        Task<IDbResponse> QueryAsync<T, U>(string storedProcedure, U parameters);
    }
}
