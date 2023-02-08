SELECT	[a].[Name], 
		DATEPART(Year, [a].BirthDate) AS [BirthYear], 
		[at].AnimalType 
FROM [Animals] AS [a]
		JOIN [AnimalTypes] AS [at] ON [at].Id = [a].AnimalTypeId
WHERE 
	[a].OwnerId IS NULL AND 
	[a].[AnimalTypeId] <> 3 AND
	DATEDIFF(YEAR, [BirthDate], '2022-01-01') < 5 
ORDER BY [a].[Name]