SELECT TOP(10) [c].Id, [c].[Name] AS [City], [c].CountryCode, COUNT([a].Id) AS [Accounts] FROM [Accounts] AS [a]
JOIN [Cities] AS [c] ON [c].Id = [a].CityId
GROUP BY [c].Id, [c].[Name], [c].CountryCode
ORDER BY [Accounts] DESC