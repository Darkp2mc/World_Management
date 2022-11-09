CREATE PROCEDURE [dbo].[AddItem] @name nvarchar(100),
								 @base_cost int,
								 @weight float,
								 @rarity nvarchar(100),
								 @type nvarchar(100)
AS
BEGIN
	INSERT INTO Items(Name, Base_cost, Weight, Rarity, Type)
	VALUES (@name, @base_cost, @weight, @rarity, @type);
END