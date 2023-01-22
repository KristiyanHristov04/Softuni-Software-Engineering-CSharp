CREATE OR ALTER PROCEDURE usp_GetEmployeesSalaryAboveNumber (@SalaryLimit DECIMAL(18, 4))
AS
SELECT [FirstName],
[LastName]
FROM [Employees]
WHERE [Salary] >= @SalaryLimit

EXEC usp_GetEmployeesSalaryAboveNumber 48100