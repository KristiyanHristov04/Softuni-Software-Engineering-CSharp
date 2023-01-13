SELECT [e2].EmployeeID, [e2].FirstName, [e2].ManagerID, [e].FirstName FROM [Employees] AS [e]
JOIN [Employees] AS [e2] ON [e2].ManagerID = [e].EmployeeID
WHERE [e2].ManagerID IN (3, 7)
ORDER BY [e2].EmployeeID