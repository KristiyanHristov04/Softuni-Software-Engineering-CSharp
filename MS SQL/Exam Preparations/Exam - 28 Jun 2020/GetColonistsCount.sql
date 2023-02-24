CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
	BEGIN
		DECLARE @count INT =
		(
				SELECT COUNT(*) FROM [Journeys] AS [j]
				JOIN [Spaceports] AS [sp] ON [sp].Id = [j].DestinationSpaceportId
				JOIN [TravelCards] AS [tc] ON [tc].JourneyId = [j].Id
				WHERE [DestinationSpaceportId] IN
				(
					SELECT [Id] FROM [Spaceports]
					WHERE [PlanetId] = 
					(
						SELECT [Id] FROM [Planets]
						WHERE [Name] = @PlanetName
					)
				)
		)
		RETURN @count
	END

GO

SELECT dbo.udf_GetColonistsCount('Otroyphus')