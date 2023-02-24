SELECT [e].[EmployeeID],
[e].[FirstName]
FROM [Employees] AS [e]
LEFT JOIN [EmployeesProjects] AS [p] ON [e].EmployeeID = [p].EmployeeID


--SELECT * FROM [Addresses]
--SELECT * FROM [Departments]
--SELECT * FROM [EmployeesProjects]
--SELECT * FROM [Employees]