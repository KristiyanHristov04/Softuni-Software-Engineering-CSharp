CREATE PROCEDURE usp_EmployeesBySalaryLevel (@LevelOfSalary VARCHAR(10))
AS
	SELECT [FirstName],
	[LastName]
	FROM [Employees]
	WHERE [dbo].ufn_GetSalaryLevel ([Salary]) = @LevelOfSalary

EXEC usp_EmployeesBySalaryLevel 'High'
