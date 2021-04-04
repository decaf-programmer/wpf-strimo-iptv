CREATE PROCEDURE [dbo].[spUserLookup]
	@id int = 0
AS
begin
	set nocount on;

	select id, username, password, loginStatus, token, lastLoginDate
	from [dbo].[User]
	where Id=@Id;
end
