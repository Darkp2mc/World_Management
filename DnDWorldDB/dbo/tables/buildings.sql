﻿CREATE TABLE [dbo].[Buildings]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NCHAR(100) NULL, 
    [IsShop] INT NOT NULL DEFAULT 0, 
    [CityTypeId] INT NOT NULL
)
