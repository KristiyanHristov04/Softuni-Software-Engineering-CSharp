SELECT [s].[Name], [l].[Name], [s].Establishment, [c].[Name] FROM [Sites] AS [s]
LEFT JOIN [Locations] AS [l] ON [l].Id = [s].LocationId
LEFT JOIN [Categories] AS [c] ON   [c].Id = [s].CategoryId
ORDER BY [c].[Name] DESC, [l].[Name] ASC, [s].[Name] ASC 