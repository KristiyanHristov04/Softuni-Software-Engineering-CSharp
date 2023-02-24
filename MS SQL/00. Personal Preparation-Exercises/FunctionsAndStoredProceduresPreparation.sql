--Scalar Function
CREATE OR ALTER FUNCTION udf_ShowLeftWeeks (@startDate DATETIME, @endDate DATETIME)
RETURNS INT
AS
	BEGIN
		DECLARE @leftWeeks INT
		IF(@endDate IS NULL)
		BEGIN
			SET @endDate = GETDATE()
		END
		SET @leftWeeks = DATEDIFF(WEEK, @startDate, @endDate)
		RETURN @leftWeeks
	END

GO

SELECT	[ProjectID], 
		[Name], 
		[Description], 
		[StartDate],
		[EndDate],
		[dbo].udf_ShowLeftWeeks ([StartDate], [EndDate]) AS [WeeksLeft]
FROM [Projects]

GO

SELECT [dbo].udf_ShowLeftWeeks ('01-01-2023', '01-24-2023') AS [LeftWeeks]

GO

--Table-Valued Function
CREATE OR ALTER FUNCTION udf_ShowDepartmentAverageSalary()
RETURNS TABLE AS
RETURN
	(
		SELECT [d].[DepartmentID], 
		[d].[Name],
		AVG([e].Salary) AS [AverageSalary]
		FROM [Employees] AS [e]
		JOIN [Departments] AS [d] ON [d].DepartmentID = [e].DepartmentID
		GROUP BY [d].[DepartmentID], [d].[Name]
	)

GO

SELECT * FROM [dbo].udf_ShowDepartmentAverageSalary()

GO

SELECT * FROM [Employees]

GO

--Practice on Scalar Functions
CREATE OR ALTER FUNCTION udf_ShowSalaryLevel(@salary MONEY)
RETURNS VARCHAR(50)
AS
	BEGIN
		DECLARE @salaryLevel VARCHAR(50)		
		IF (@salary < 30000)
		BEGIN
			SET @salaryLevel = 'Low'
		END
		ELSE IF(@salary BETWEEN 30000 AND 50000)
		BEGIN
			SET @salaryLevel = 'Average'
		END
		ELSE
		BEGIN
			SET @salaryLevel = 'High'
		END
		RETURN @salaryLevel
	END

GO

SELECT  [FirstName],
		[LastName],
		[Salary],
		[dbo].udf_ShowSalaryLevel([Salary]) AS [SalaryLevel]
FROM [Employees]

GO

--Stored Procedure Without Parameters
CREATE OR ALTER PROCEDURE usp_ShowEmployeesBySeniority
AS
	BEGIN
		SELECT * FROM [Employees]
		WHERE DATEDIFF(YEAR, [HireDate], GETDATE()) > 20
	END

GO

EXECUTE [dbo].usp_ShowEmployeesBySeniority

GO

--Stored Procedure With Parameters
CREATE OR ALTER PROCEDURE usp_ShowEmployeesBySeniorityWithParameter(@minimumWorkYears INT = 22) --Default value -> can be overriden when executing the procedure
AS
	BEGIN
		SELECT * FROM [Employees]
		WHERE DATEDIFF(YEAR, [HireDate], GETDATE()) > @minimumWorkYears
		ORDER BY [HireDate]
	END

GO

EXECUTE [dbo].usp_ShowEmployeesBySeniorityWithParameter 23

GO

--Stored Procedure Returning Multiple Results
CREATE OR ALTER PROCEDURE usp_ShowMultipleResults
AS
	SELECT [HireDate] FROM [Employees]
	SELECT [FirstName], [LastName] FROM [Employees]
	SELECT [e].FirstName, [e].LastName, [d].[Name] AS [Department]
	FROM [Employees] AS [e]
	JOIN [Departments] AS [d] ON [d].DepartmentID = [e].DepartmentID

GO

EXECUTE [dbo].usp_ShowMultipleResults

GO

--Error Throwing
CREATE OR ALTER PROCEDURE usp_ShowIfPersonMeetsAgeRestriction (@personAge INT)
AS
	BEGIN
		IF(@personAge < 18)
		BEGIN
			THROW 50001, 'Person is too young!', 1
		END
	END

GO

EXEC [dbo].usp_ShowIfPersonMeetsAgeRestriction 12