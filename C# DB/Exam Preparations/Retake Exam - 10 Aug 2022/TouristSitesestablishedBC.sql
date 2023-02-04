SELECT [s].[Name], [l].[Name] AS [Location], [l].Municipality, [l].Province, [s].Establishment FROM [Sites] AS [s]
JOIN [Locations] AS [l] ON [l].Id = [s].LocationId
WHERE [Establishment] LIKE '%BC%'
AND [s].[Name] LIKE '[^M]%' AND [s].[Name] LIKE '[^B]%' AND [s].[Name] LIKE '[^D]%'
ORDER BY [s].[Name]