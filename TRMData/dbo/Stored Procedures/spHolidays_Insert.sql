CREATE PROCEDURE [dbo].[spHolidays_Insert]

	@IdHolidayType int,
	@Data datetime2,
	@IdUser int,
	@HolidayTypeId int
AS
begin
	set nocount on;
	insert into dbo.Holidays(IdHolidayType, [Data], IdUser, HolidayTypeId)
	values(@IdHolidayType, @Data, @IdUser, @HolidayTypeId);

end