CREATE TABLE [dbo].[Provinces]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(100) NOT NULL, 
    [State] INT NOT NULL, 
    [Form] NCHAR(100) NOT NULL, 
    [Area] INT NOT NULL, 
    [Population] INT NOT NULL
)
