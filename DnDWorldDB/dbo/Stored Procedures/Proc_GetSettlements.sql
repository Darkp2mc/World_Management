CREATE PROCEDURE [dbo].[GetSettlements]
AS
BEGIN
	SELECT Id, Name, Is_Capital, Population, CityType, Province, State, Form
	FROM Settlements
END