SELECT [e].[FirstName], [e].[LastName], [e].[HireDate], [d].[Name] AS [DeptName] FROM [Employees] AS [e]
JOIN [Departments] AS [d] ON [e].[DepartmentID] = [d].[DepartmentID]
WHERE ([d].[Name] = 'Sales' OR [d].[Name] = 'Finance') AND [e].[HireDate] > '01/01/1999'
ORDER BY [e].[HireDate]