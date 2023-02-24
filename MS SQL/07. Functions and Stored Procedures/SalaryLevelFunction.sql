CREATE OR ALTER FUNCTION ufn_GetSalaryLevel (@Salary DECIMAL(18,4))
RETURNS VARCHAR(10)
BEGIN
	DECLARE @SalaryLevel VARCHAR(10)
	IF(@Salary < 30000)
	BEGIN
		SET @SalaryLevel = 'Low'
	END
	ELSE IF(@Salary BETWEEN 30000 AND 50000)
	BEGIN
		SET @SalaryLevel = 'Average'
	END
	ELSE
	BEGIN
		SET @SalaryLevel = 'High'
	END

	RETURN @SalaryLevel
END

SELECT [Salary],
[dbo].ufn_GetSalaryLevel([Salary]) AS [Salary level]
FROM [Employees]
