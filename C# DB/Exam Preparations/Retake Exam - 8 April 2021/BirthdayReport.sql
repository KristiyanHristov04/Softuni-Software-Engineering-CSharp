SELECT [u].Username, [c].[Name] AS [CategoryName] FROM [Users] AS [u]
JOIN [Reports] AS [r] ON [r].UserId = [u].Id
JOIN [Categories] AS [c] ON [c].Id = [r].CategoryId
WHERE DATEPART(MONTH, [u].BirthDate) = DATEPART(MONTH, [r].OpenDate) AND 
DATEPART(DAY, [u].BirthDate) = DATEPART(DAY, [r].OpenDate)
ORDER BY [u].Username, [c].[Name]
