CREATE TABLE [dbo].[Settlements]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(100) NOT NULL, 
    [Is_Capital] INT NOT NULL, 
    [Population] INT NOT NULL, 
    [CityType] INT NOT NULL,
    [Province] INT NOT NULL, 
    [State] INT NOT NULL
)
