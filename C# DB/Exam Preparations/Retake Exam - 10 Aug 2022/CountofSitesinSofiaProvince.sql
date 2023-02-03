SELECT [l].[Province], [l].Municipality, [l].[Name], COUNT([l].Id) AS [CountOfSites] FROM [Locations] AS [l]
JOIN [Sites] AS [s] ON [s].LocationId = [l].Id
WHERE [Province] = 'Sofia'
GROUP BY [l].[Province], [l].Municipality, [l].[Name]
ORDER BY COUNT([l].Id) DESC, [l].[Name]

SELECT * FROM [Sites]


SELECT * FROM [Locations] AS [l]
JOIN [Sites] AS [s] ON [s].LocationId = [l].Id
WHERE [Province] = 'Sofia'