CREATE PROCEDURE [dbo].[spUserStocksDeleteStock]
	@UserId NVARCHAR(128),
	@Ticker NVARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM UserStocks
	WHERE UserId = @UserId AND Ticker = @Ticker
END
