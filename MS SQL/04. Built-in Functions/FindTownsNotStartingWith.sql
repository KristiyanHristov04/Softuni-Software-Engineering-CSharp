SELECT [TownID], [Name]
FROM [Towns]
WHERE [Name] NOT LIKE 'B%' AND
[Name] NOT LIKE 'D%' AND
[Name] NOT LIKE 'R%'
ORDER BY [Name]

SELECT * FROM [Towns]