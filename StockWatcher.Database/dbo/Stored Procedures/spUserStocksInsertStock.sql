CREATE PROCEDURE [dbo].[spUserStocksInsertStock]
	@UserId NVARCHAR(128),
	@Ticker NVARCHAR(10)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.UserStocks([UserId], [Ticker])
	VALUES(@UserId, @Ticker);
END
