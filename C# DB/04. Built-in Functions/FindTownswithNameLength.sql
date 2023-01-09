SELECT [Name]
FROM [Towns]
WHERE LEN([Name]) >= 5 AND LEN([Name]) <= 6
ORDER BY [Name]