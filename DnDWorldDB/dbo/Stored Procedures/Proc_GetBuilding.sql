CREATE PROCEDURE [dbo].[GetBuildings]
AS
BEGIN
	SELECT Id, Name, IsShop, CityTypeId
	FROM Buildings
END
