CREATE TABLE [dbo].[UserStocks]
(
	[UserId] NVARCHAR(128) NOT NULL, 
	[Ticker] NVARCHAR(10) NOT NULL, 
	PRIMARY KEY ([UserId], [Ticker]),
    CONSTRAINT [FK_UserStocks_ToUsers] FOREIGN KEY ([UserId]) REFERENCES [Users](Id)
)
