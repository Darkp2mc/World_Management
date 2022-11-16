CREATE PROCEDURE [dbo].[GetProvinceOfState] @id int
AS
BEGIN
	SELECT Id, Name, State, Form, Area, Population
	FROM Provinces
	WHERE @id = State
END
