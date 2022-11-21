﻿CREATE PROCEDURE [dbo].[GetProvinceById] @id int
AS
BEGIN
	SELECT Id, Name, State, Form, Area, Population
	FROM Provinces
	WHERE @id = Id
END