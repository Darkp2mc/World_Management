CREATE PROCEDURE [dbo].[GetItems]
AS
BEGIN
	SELECT Id, Name, Base_cost, Weight, Rarity, Type
	FROM Items
END
