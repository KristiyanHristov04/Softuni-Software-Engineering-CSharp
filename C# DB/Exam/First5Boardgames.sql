SELECT TOP(5) [bg].[Name], [bg].Rating, [c].[Name] FROM [Boardgames] AS [bg]
JOIN [PlayersRanges] AS [pr] ON [bg].PlayersRangeId = [pr].Id
JOIN [Categories] AS [c] ON [bg].CategoryId = [c].Id
WHERE [Rating] > 7.00 AND
([bg].[Name] LIKE '%a%' OR [Rating] > 7.50) AND
[pr].PlayersMin >= 2 AND [pr].PlayersMax <= 5
ORDER BY [bg].[Name] ASC, [bg].Rating DESC
