CREATE PROCEDURE [dbo].[spUserStocksGetStocksByUserId]
	@UserId NVARCHAR(128)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Ticker] 
	FROM [UserStocks]
	WHERE UserId = @UserId

END
