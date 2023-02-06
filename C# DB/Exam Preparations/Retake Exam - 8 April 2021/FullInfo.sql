SELECT  IIF([e].FirstName IS NULL, 'None', CONCAT([e].FirstName, ' ', [e].LastName)) AS [Employee],
		IIF([d].[Name] IS NULL, 'None', [d].[Name]) AS [Department],
		[c].[Name] AS [Category],
		[r].[Description],
		FORMAT([r].OpenDate, 'dd.MM.yyyy') AS [OpenDate],
		[s].[Label] AS [Status], 
		[u].[Name] AS [User]
FROM [Reports] AS [r]
		LEFT JOIN [Employees] AS [e] ON [e].Id = [r].EmployeeId
		LEFT JOIN [Departments] AS [d] ON [d].Id = [e].DepartmentId
		LEFT JOIN [Categories] AS [c] ON [c].Id = [r].CategoryId
		LEFT JOIN [Status] AS [s] ON [s].Id = [r].StatusId
		LEFT JOIN [Users] AS [u] ON [u].Id = [r].UserId
ORDER BY [e].FirstName DESC,
[e].LastName DESC,
[Department] ASC, 
[Category] ASC, 
[Description] ASC, 
[OpenDate] ASC,
[Status] ASC, 
[User] ASC
