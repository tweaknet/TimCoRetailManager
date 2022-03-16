CREATE TABLE [dbo].[Holidays]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [IdHolidayType] INT NOT NULL, 
    [Data] DATETIME2 NOT NULL, 
    [IdUser] INT NOT NULL, 
    [HolidayTypeId] INT NOT NULL
)
