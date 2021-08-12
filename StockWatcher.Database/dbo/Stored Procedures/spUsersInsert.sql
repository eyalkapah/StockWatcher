CREATE PROCEDURE [dbo].[spUsersInsert]
	--@param1 int = 0,
	--@param2 int
AS
BEGIN
	--SELECT @param1, @param2
	INSERT INTO dbo.Users([Email], [Password], [FirstName], [LastName])
	VALUES('kaycee1@gmail.com', '1122', 'Eyal', 'Kapah');

END
