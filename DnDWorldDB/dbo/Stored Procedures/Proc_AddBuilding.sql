CREATE PROCEDURE [dbo].[AddBuilding] @name nvarchar(100), @isShop int
AS
BEGIN
	INSERT INTO Buildings(Name, IsShop)
	VALUES (@name, @isShop);
END