SELECT COUNT(*) AS [Count] FROM [Colonists] AS [c]
JOIN [TravelCards] AS [tc] ON [tc].ColonistId = [c].Id
JOIN [Journeys] AS [j] ON [j].Id = [tc].JourneyId
WHERE [j].Purpose = 'Technical'