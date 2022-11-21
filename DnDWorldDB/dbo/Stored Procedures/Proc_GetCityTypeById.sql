CREATE PROCEDURE [dbo].[GetCityTypeById] @id int
AS
BEGIN
	SELECT Id, Name
	FROM CityTypes
	WHERE @id = Id
END