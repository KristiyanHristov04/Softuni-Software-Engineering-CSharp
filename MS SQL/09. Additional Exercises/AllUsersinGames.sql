SELECT [g].[Name], [gt].[Name], [u].Username, [ug].[Level], [ug].Cash, [c].[Name] FROM [Games] AS [g]
LEFT JOIN [GameTypes] AS [gt] ON [gt].Id = [g].GameTypeId
LEFT JOIN [UsersGames] AS [ug] ON [ug].GameId = [g].Id
RIGHT JOIN [Users] AS [u] ON [u].Id = [ug].UserId
LEFT JOIN [Characters] AS [c] ON [c].Id = [ug].CharacterId
ORDER BY [ug].[Level] DESC, [u].Username ASC, [g].[Name] ASC
