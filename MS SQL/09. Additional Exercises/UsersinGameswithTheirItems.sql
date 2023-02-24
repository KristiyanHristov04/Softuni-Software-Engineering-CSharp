SELECT [u].Username, [g].[Name] AS [Game], COUNT(*) AS [Items Count], SUM([Price]) AS [Items Price] FROM [Users] AS [u]
LEFT JOIN  [UsersGames] AS [ug] ON [ug].UserId = [u].Id
LEFT JOIN [UserGameItems] AS [ugi] ON [ugi].UserGameId = [ug].Id
LEFT JOIN [Items] AS [i] ON [i].Id = [ugi].ItemId
LEFT JOIN [Games] AS [g] ON [g].Id = [ug].GameId
GROUP BY [u].Username, [g].[Name]
HAVING COUNT(*) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, [u].Username ASC