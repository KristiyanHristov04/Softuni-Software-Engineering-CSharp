SELECT * FROM
(
	SELECT [tc].JobDuringJourney,
	CONCAT([c].FirstName, ' ', [c].LastName) AS [FullName],
	DENSE_RANK() OVER(PARTITION BY [tc].JobDuringJourney ORDER BY [c].BirthDate ASC) AS [JobRank]
	FROM [TravelCards] AS [tc]
	JOIN [Colonists] AS [c] ON [c].Id = [tc].ColonistId
) AS [data]
WHERE [data].JobRank = 2
