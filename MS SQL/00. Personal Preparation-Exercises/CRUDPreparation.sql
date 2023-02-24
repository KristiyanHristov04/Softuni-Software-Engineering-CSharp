SELECT CONCAT([e].[FirstName], ' ', [e].[LastName]) AS [FullName],
[e].JobTitle, 
[e].Salary 
FROM [Employees] AS [e]

GO

SELECT DISTINCT [Salary] FROM [Employees]
ORDER BY [Salary]

GO

SELECT * FROM [Employees]
WHERE [ManagerID] = 6

GO

CREATE VIEW v_DisplayEmployeesWithSalaryHigherThan30000 AS
SELECT * FROM [Employees]
WHERE [Salary] > 30000

GO

SELECT * FROM [v_DisplayEmployeesWithSalaryHigherThan30000]
ORDER BY [Salary]

GO

CREATE VIEW v_ShowPersonWithHighestSalary AS
SELECT TOP(1) [EmployeeID], [FirstName], [LastName], [Salary] AS [HighestSalary] FROM [Employees]
ORDER BY [Salary] DESC

GO

SELECT * FROM [v_ShowPersonWithHighestSalary]

GO

SELECT * FROM [EmployeesAS]

GO

INSERT INTO [EmployeesAS]([FirstName], [LastName], [JobTitle], [DepartmentID], [HireDate], [Salary])
	VALUES 
		('Kristiyan', 'Hristov', 'Software Engineer', 1, GETDATE(), 27000)

GO

SELECT [FirstName], [LastName] 
INTO [TempTable]
FROM [Employees]

GO

SELECT * FROM [TempTable]

GO

SELECT * FROM [EmployeesAS]

GO

DELETE FROM [EmployeesAS]
WHERE [DepartmentID] = 1

GO

TRUNCATE TABLE [TempTable]

GO

SELECT * FROM [TempTable]

GO

UPDATE [EmployeesAS]
SET [FirstName] = 'Jordjano'
WHERE [DepartmentID] IN (11, 5)

GO

