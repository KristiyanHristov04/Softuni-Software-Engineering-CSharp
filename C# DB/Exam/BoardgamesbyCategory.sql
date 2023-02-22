SELECT [bg].Id, [bg].[Name], [bg].[YearPublished], [c].[Name] AS [CategoryName] FROM [Boardgames] AS [bg]
JOIN [Categories] AS [c] ON [bg].CategoryId = [c].Id
WHERE [c].[Name] = 'Strategy Games' OR
[c].[Name] = 'Wargames'
ORDER BY [bg].YearPublished DESC