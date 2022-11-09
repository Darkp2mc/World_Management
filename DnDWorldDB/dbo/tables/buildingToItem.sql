CREATE TABLE [dbo].[BuildingToItem]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Id_building] INT NOT NULL, 
    [Id_item] INT NOT NULL 
)
