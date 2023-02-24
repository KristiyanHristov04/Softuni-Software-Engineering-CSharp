--GROUP BY
SELECT [DepartmentID], SUM([Salary]) AS [TotalSum] FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID] ASC

GO

SELECT [DepartmentID], MIN([Salary]) AS [MinSalary] FROM [Employees]
GROUP BY [DepartmentID]

GO

SELECT [DepartmentID], COUNT(*) FROM [Employees]
GROUP BY [DepartmentID]

GO

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary] FROM [Employees]
GROUP BY [DepartmentID]

GO

SELECT STRING_AGG([FirstName], ',') FROM [Employees]

GO

--HAVING
SELECT [DepartmentID], SUM([Salary]) AS [TotalSalary] FROM [Employees]
GROUP BY [DepartmentID]
HAVING SUM([Salary]) >= 200000

GO

SELECT [DepartmentID], AVG([Salary]) AS [AverageSalary] FROM [Employees]
GROUP BY [DepartmentID]
HAVING [DepartmentID] % 2 = 0





