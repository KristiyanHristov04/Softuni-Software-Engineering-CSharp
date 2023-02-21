SELECT [data].CountryName, [data].DistributorName FROM 
(
	SELECT  [c].[Name] AS [CountryName], 
			[d].[Name] AS [DistributorName], 
			COUNT(*) AS [MostDeliveredIngredients],
			RANK() OVER (PARTITION BY [c].[Name] ORDER BY COUNT([i].Id) DESC) AS [Rank]
	FROM [Countries] AS [c]
			LEFT JOIN [Distributors] AS [d] ON [d].CountryId = [c].Id
			LEFT JOIN [Ingredients] AS [i] ON [i].DistributorId = [d].Id
	GROUP BY [c].[Name], [d].[Name]
) AS [data]
WHERE [data].[Rank] = 1
ORDER BY [CountryName], [DistributorName]