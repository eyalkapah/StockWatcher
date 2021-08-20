namespace StockWatcher.Common
{
    public class StoredProcedures
    {
        public const string UsersInsert = "dbo.spUsersInsert";
        public const string UserGetByEmail = "dbo.spUserGetByEmail";
        public const string UserStocksGetStocksByUserId = "dbo.spUserStocksGetStocksByUserId";
        public const string UserStocksInsertStock = "dbo.spUserStocksInsertStock";
    }
}
