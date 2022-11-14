CREATE TABLE [dbo].[CityTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(100) NULL, 
    [MinPopulation] INT NOT NULL, 
    [MaxPopulation] INT NULL
)