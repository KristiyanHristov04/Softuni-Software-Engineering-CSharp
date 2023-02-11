SELECT [FirstName], [LastName], FORMAT([BirthDate], 'MM-dd-yyyy'), [c].[Name] AS [HomeTown], [Email] FROM [Accounts] AS [a]
JOIN [Cities] AS [c] ON [c].Id = [a].CityId
WHERE [Email] LIKE 'e%'
ORDER BY [c].[Name]
