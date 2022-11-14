CREATE PROCEDURE [dbo].[GetBuildings]
AS
BEGIN
	SELECT Id, Name, IsShop
	FROM Buildings
END
