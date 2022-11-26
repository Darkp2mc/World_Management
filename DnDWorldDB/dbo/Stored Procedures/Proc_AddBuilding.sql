CREATE PROCEDURE [dbo].[AddBuilding] @name nvarchar(100), @isShop int, @cityTypeId int
AS
BEGIN
	INSERT INTO Buildings(Name, IsShop, CityTypeId)
	VALUES (@name, @isShop, @cityTypeId);
END