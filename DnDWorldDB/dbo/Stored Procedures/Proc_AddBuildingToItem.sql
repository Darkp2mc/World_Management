CREATE PROCEDURE [dbo].[AddBuildingToItem] @id_building int,
										   @id_item int
AS
BEGIN
	INSERT INTO BuildingToItem(Id_building, Id_item)
	VALUES (@id_building, @id_item);
END
