CREATE PROCEDURE [dbo].[spHolidaysLookup]
	@Id int
AS
begin
set nocount on;

	SELECT Id,HolidayTypeId,IdHolidayType,IdUser,[Data]
	from [dbo].[Holidays]
	where Id=@Id
end
RETURN 0
