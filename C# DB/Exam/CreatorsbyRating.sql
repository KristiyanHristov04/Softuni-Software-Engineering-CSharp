SELECT [c].LastName, CEILING(AVG([bg].Rating)) AS [AverageRating] , [p].[Name] AS [PublisherName] FROM [Creators] AS [c]
JOIN [CreatorsBoardgames] AS [cb] ON [c].Id = [cb].CreatorId
JOIN [Boardgames] AS [bg] ON [cb].BoardgameId = [bg].Id
JOIN [Publishers] AS [p] ON [bg].PublisherId = [p].Id
GROUP BY [c].LastName, [p].[Name]
HAVING [p].[Name] = 'Stonemaier Games'
ORDER BY AVG([bg].Rating) DESC