CREATE PROCEDURE [dbo].[AddBuilding] @name nvarchar(100)
AS
BEGIN
	INSERT INTO Buildings(Name)
	VALUES (@name);
END