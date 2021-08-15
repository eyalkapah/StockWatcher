using System;
using System.Collections.Generic;
using Dapper;
using StockWatcher.Services.Interfaces;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace StockWatcher.Services.Services
{
    public class DbService : IDbService
    {
        private readonly string _connectionString;

        public DbService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task ExecuteAsync<T>(string storedProcedure, T parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var affectedRows = await connection.ExecuteAsync(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<List<T>> QueryAsync<T, U>(string storedProcedure, U parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<T>(storedProcedure, parameters,
                        commandType: CommandType.StoredProcedure);

                    return result.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    return null;
                }
               
            }
        }
    }
}
