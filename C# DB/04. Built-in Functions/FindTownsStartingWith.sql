SELECT [TownID], [Name]
FROM [Towns]
WHERE [Name] LIKE 'B%' OR 
[Name] LIKE 'E%' OR
[Name] LIKE 'M%' OR
[Name] LIKE 'K%'
ORDER BY [Name]