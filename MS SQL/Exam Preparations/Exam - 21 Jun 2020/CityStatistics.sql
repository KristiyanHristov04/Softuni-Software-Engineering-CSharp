SELECT [c].[Name], COUNT([h].Id) AS [Hotels] FROM [Cities] AS [c]
JOIN [Hotels] AS [h] ON [h].CityId = [c].Id
GROUP BY [c].[Name]
ORDER BY [Hotels] DESC, [c].[Name]