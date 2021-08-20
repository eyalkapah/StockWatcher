using Dapper;
using StockWatcher.Models.Models.DbResponse;
using StockWatcher.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public async Task<IDbResponse> ExecuteAsync<T>(string storedProcedure, T parameters)
        {
            IDbResponse response;

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var affectedRows = await connection.ExecuteAsync(storedProcedure, parameters,
                        commandType: CommandType.StoredProcedure);

                    response = new DbSuccessResponse<object>
                    {
                        RowsAffected = affectedRows
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    response = new DbErrorResponse
                    {
                        Message = ex.Message
                    };
                }
            }

            return response;
        }

        public async Task<IDbResponse> QueryAsync<T, U>(string storedProcedure, U parameters)
        {
            IDbResponse response;

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    var result = await connection.QueryAsync<T>(storedProcedure, parameters,
                        commandType: CommandType.StoredProcedure);

                    return new DbSuccessResponse<IEnumerable<T>>
                    {
                        Result = result,
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);

                    return new DbErrorResponse
                    {
                        Message = ex.Message
                    };
                }
               
            }
        }
    }
}
