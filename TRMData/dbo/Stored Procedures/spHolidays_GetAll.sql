CREATE PROCEDURE [dbo].[spHolidays_GetAll]
AS
begin
set nocount on;
	select [Id], [IdHolidayType], [Data], [IdUser],[HolidayTypeId]
	from dbo.Holidays
end
