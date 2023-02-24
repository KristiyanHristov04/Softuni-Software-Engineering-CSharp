SELECT [DepartmentID], MIN([Salary]) AS [MinimumSalary] FROM [Employees]
GROUP BY [DepartmentID]
HAVING [DepartmentID] IN (2, 5, 7)