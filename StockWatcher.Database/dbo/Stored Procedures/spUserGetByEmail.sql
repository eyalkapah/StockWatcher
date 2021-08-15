CREATE PROCEDURE [dbo].[spUserGetByEmail]
	@Email NVARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT [Email], [Password], [FirstName], [LastName]
	FROM dbo.Users
	WHERE Email = @Email;

END
