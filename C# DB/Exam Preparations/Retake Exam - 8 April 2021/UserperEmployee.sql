SELECT [FullName], COUNT([data].UserId) AS [UsersCount] FROM 
(
	SELECT CONCAT([e].FirstName, ' ', [e].LastName) AS [FullName], [r].UserId FROM [Employees] AS [e]
	LEFT JOIN [Reports] AS [r] ON [r].EmployeeId = [e].Id
) AS [data]
GROUP BY [FullName]
ORDER BY [UsersCount] DESC, [FullName] ASC