CREATE PROCEDURE [dbo].[GetBuildings]
AS
BEGIN
	SELECT Id, Name
	FROM Buildings
END
