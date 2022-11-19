CREATE PROCEDURE [dbo].[Proc_GetCityTypeById] @id int
AS
BEGIN
	SELECT Id, Name
	FROM CityTypes
	WHERE @id = Id
END