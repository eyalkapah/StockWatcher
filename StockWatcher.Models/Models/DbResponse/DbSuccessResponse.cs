namespace StockWatcher.Models.Models.DbResponse
{
    public class DbSuccessResponse<T> : IDbResponse
    {
        public int RowsAffected { get; set; }

        public T Result { get; set; }

        
    }
}
