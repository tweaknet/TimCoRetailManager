﻿CREATE PROCEDURE [dbo].[spUserLookup]
	@Id nvarchar(128)
AS
begin
set nocount on;
	SELECT FirstName, LastName, EmailAddress
	from [dbo].[User]
	where Id=@Id
end
RETURN 0
