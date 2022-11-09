CREATE TABLE [dbo].[Items]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Base_cost] INT NOT NULL,
	[Weight] Float,
	[Rarity] NVARCHAR(100), 
    [Type] NVARCHAR(100) NULL
)
