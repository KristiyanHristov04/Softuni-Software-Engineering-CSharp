SELECT CONCAT([o].[Name], '-', [a].[Name]) AS [OwnersAnimals],  [o].PhoneNumber, [ac].CageId FROM [Animals] AS [a]
JOIN [AnimalTypes] AS [at] ON [at].Id = [a].AnimalTypeId
JOIN [Cages] AS [c] ON [c].AnimalTypeId = [at].Id
JOIN [AnimalsCages] AS [ac] ON [ac].AnimalId = [a].Id
JOIN [Owners] AS [o] ON [o].Id = [a].OwnerId
WHERE [a].[AnimalTypeId] =  (
							SELECT [Id] FROM [AnimalTypes]
							WHERE [AnimalType] = 'Mammals'
						)
GROUP BY [a].[Name], [ac].CageId, [o].[Name], [o].PhoneNumber
ORDER BY [o].[Name], [a].[Name] DESC 

