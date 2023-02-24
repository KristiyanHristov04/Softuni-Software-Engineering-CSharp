SELECT [f].Id, [f].[Name], CONCAT([f].Size, 'KB') FROM [Files] AS [f]
LEFT JOIN [Files] AS [f2] ON [f2].ParentId = [f].Id
WHERE [f2].Id IS NULL
ORDER BY [f].Id ASC, [f].[Name] ASC, [f].Size DESC