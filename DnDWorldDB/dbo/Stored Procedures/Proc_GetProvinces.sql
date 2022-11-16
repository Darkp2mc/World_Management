CREATE PROCEDURE [dbo].[GetProvinces]
AS
BEGIN
	SELECT Id, Name, State, Form, Area, Population
	FROM Provinces
END