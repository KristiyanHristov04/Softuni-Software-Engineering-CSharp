SELECT [data].[Name], [data].Manufacturer FROM
(
	SELECT [s].[Name], [s].Manufacturer, [c].BirthDate, [tc].JobDuringJourney, DATEDIFF(YEAR, [c].BirthDate, '2019-01-01')  AS [Years] FROM [Spaceships] AS [s]
	JOIN [Journeys] AS [j] ON [j].SpaceshipId = [s].Id
	JOIN [TravelCards] AS [tc] ON [tc].JourneyId = [j].Id
	JOIN [Colonists] AS [c] ON [c].Id = [tc].ColonistId
	WHERE [tc].JobDuringJourney = 'Pilot'
) AS [data]
WHERE [data].Years < 30
ORDER BY [data].[Name]