

GO

CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
AS
	BEGIN
		DECLARE @touristsCount INT =
		(
				SELECT COUNT([t].Id) FROM [Sites] AS [s]
				JOIN [SitesTourists] AS [st] ON [st].SiteId = [s].Id
				JOIN [Tourists] AS [t] ON [t].Id = [st].TouristId
				GROUP BY [s].[Name]
				HAVING [s].[Name] = @Site
		)
		RETURN @touristsCount
	END

GO

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Regional History Museum – Vratsa')

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Samuil’s Fortress')

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')