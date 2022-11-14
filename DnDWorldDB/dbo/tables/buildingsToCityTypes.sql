CREATE TABLE [dbo].[BuildingsToCityTypes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Id_building] INT NOT NULL, 
    [Id_cityType] INT NOT NULL 
)