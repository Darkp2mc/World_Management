CREATE PROCEDURE [dbo].[GetCityTypes]
AS
BEGIN
	SELECT Id, Name, MinPopulation, MaxPopulation
	FROM CityTypes
END
