SELECT [a].[Name], [at].AnimalType, FORMAT([a].BirthDate, 'dd.MM.yyyy') FROM [Animals] AS [a]
JOIN [AnimalTypes] AS [at] ON [at].Id = [a].AnimalTypeId
ORDER BY [a].[Name]