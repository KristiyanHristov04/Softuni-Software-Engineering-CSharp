--JOINS
--Inner Join queries
SELECT [e].[FirstName], [e].LastName, [d].[Name], [e].Salary FROM [Employees] AS [e]
JOIN [Departments] AS [d] ON [d].DepartmentID = [e].DepartmentID

GO

SELECT [e].FirstName, [e].LastName, [a].AddressText, [t].[Name] AS [TownName] FROM [Employees] AS [e]
JOIN [Addresses] AS [a] ON [a].AddressID = [e].AddressID
JOIN [Towns] AS [t] ON [t].TownID = [a].AddressID

GO

--Subqueries
SELECT [data].DepartmentName FROM 
	(
		SELECT [e].FirstName, [e].LastName, [d].[Name] AS [DepartmentName] FROM [Employees] AS [e]
		JOIN [Departments] AS [d] ON [d].DepartmentID = [e].DepartmentID
	) 
		AS [data]

GO

SELECT CONCAT([FirstName], ' ', [LastName]) AS [FullName], [Salary] FROM
	(
		SELECT [FirstName], [LastName], [DepartmentID], [Salary]
		FROM [Employees]
	) 
	AS [data]
	WHERE [DepartmentID] = 1

SELECT * FROM [Employees]

SELECT MIN([data].TotalSumPerDepartment) AS [MinSalary] FROM
	(	
		SELECT [DepartmentID], SUM([Salary]) AS [TotalSumPerDepartment]
		FROM [Employees]
		GROUP BY [DepartmentID]
	) AS [data]