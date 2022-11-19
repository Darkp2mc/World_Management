CREATE PROCEDURE [dbo].[GetSettlementOfProvince] @id int
AS
BEGIN
	SELECT Id, Name, Is_Capital, Population, CityType, Province, State, Form
	FROM Settlements
	WHERE @id = Province
END
