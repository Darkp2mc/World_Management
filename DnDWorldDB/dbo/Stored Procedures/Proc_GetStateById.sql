CREATE PROCEDURE [dbo].[GetStateById] @id int
AS
BEGIN
	SELECT Id, Name, Form, Area, Population
	FROM States
	WHERE @id = Id
END