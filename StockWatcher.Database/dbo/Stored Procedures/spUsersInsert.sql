CREATE PROCEDURE [dbo].[spUsersInsert]
	@Email NVARCHAR(50),
	@Password NVARCHAR(128),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50)
AS
BEGIN
	--SELECT @param1, @param2
	INSERT INTO dbo.Users([Email], [Password], [FirstName], [LastName])
	VALUES(@Email, @Password, @FirstName, @LastName);

END
