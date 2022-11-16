CREATE PROCEDURE [dbo].[GetStates]
AS
BEGIN
	SELECT Id, Name, Form, Area, Population
	FROM States
END