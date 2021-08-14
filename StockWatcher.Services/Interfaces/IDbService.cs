using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockWatcher.Services.Interfaces
{
    public interface IDbService
    {
        Task ExecuteAsync<T>(string storedProcedure, T parameters);
    }
}
