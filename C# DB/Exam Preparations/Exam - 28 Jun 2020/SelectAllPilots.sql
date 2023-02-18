SELECT * FROM [Colonists]
SELECT * FROM [TravelCards]

SELECT [c].Id, CONCAT([c].FirstName, ' ', [c].LastName) AS [Full_Name] FROM [Colonists] AS [c]
JOIN [TravelCards] AS [tc] ON [tc].ColonistId = [c].Id
WHERE [tc].JobDuringJourney = 'Pilot'
ORDER BY [c].Id ASC