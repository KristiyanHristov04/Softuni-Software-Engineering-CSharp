--String Built-In Functions
SELECT CONCAT([FirstName], ' ', [LastName]) AS [FullName] 
FROM [Employees]

SELECT CONCAT_WS('&', [FirstName], [LastName], [Salary]) FROM [Employees]

SELECT SUBSTRING([FirstName], 1, 4) FROM [Employees]

SELECT 'SoftUni' AS [Original], REPLACE('SoftUni', 'Soft', 'Hard') AS [Replaced]

SELECT '            Kristiyan' AS [Original], LTRIM('            Kristiyan') AS [LeftTrimmed]

SELECT LEN('SoftUni') AS [NumberOfChars]

SELECT DATALENGTH(CAST('SoftUni' AS NVARCHAR))

SELECT LEFT('SoftUni', 4)

SELECT RIGHT('SoftUni', 3)

SELECT UPPER('this is going to be displayed in capital letters')

SELECT LOWER('THIS IS GOING TO BE DISPLAYED IN NON-CAPITAL LETTERS')

SELECT 'SoftUni' AS [Original], REVERSE('SoftUni') AS [Reversed]

SELECT REPLICATE('SoftUni', 5)

SELECT CHARINDEX('Uni', 'SoftUni', 1)

--Math Functions
SELECT PI()

SELECT -120 AS [NegativeNumber], ABS(-120) AS [PositiveNumber]

SELECT 9 AS [Number], SQRT(9) AS [SQRT]

SELECT 4 AS [Number], SQUARE(4) AS [SQUARE]

SELECT 5 AS [Number], POWER(5, 3) AS [POWER]

SELECT PI() AS [Number], FLOOR(PI())

SELECT PI() AS [Number], CEILING(PI())

SELECT 2.424, 2 AS [Number], ROUND(2.424, 2)

--Data Functions
SELECT DATEPART(QUARTER, '04/18/2023') AS [Quarter], DATEPART(YEAR, '04/18/2023') AS [Year], DATEPART(MONTH, '04/18/2023') AS [Month], DATEPART(DAY, '04/18/2023') AS [Day]
SELECT DATEPART(QUARTER, '08/14/2023') AS [Quarter], DATEPART(YEAR, '08/14/2023') AS [Year], DATEPART(MONTH, '08/14/2023') AS [Month], DATEPART(DAY, '08/14/2023') AS [Day]
SELECT DATEPART(QUARTER, '07/12/2023') AS [Quarter], DATEPART(YEAR, '07/12/2023') AS [Year], DATEPART(MONTH, '07/12/2023') AS [Month], DATEPART(DAY, '07/12/2023') AS [Day]
SELECT DATEPART(QUARTER, '11/02/2023') AS [Quarter], DATEPART(YEAR, '11/02/2023') AS [Year], DATEPART(MONTH, '11/02/2023') AS [Month], DATEPART(DAY, '11/02/2023') AS [Day]

SELECT DATEDIFF(YEAR, '04/23/2004', '01/24/2023')

SELECT GETDATE()

SELECT COALESCE(NULL, NULL, 'Hello There')

--Ranking Functions
SELECT [FirstName], ROW_NUMBER() OVER (ORDER BY [FirstName]) AS [RowNumber]
FROM [Employees]

SELECT [EmployeeID], [FirstName], [LastName], [DepartmentID], RANK() OVER (ORDER BY [DepartmentID]) AS [Rank]
FROM [Employees]

SELECT [EmployeeID], [FirstName], [LastName], [DepartmentID], DENSE_RANK() OVER (ORDER BY [DepartmentID]) AS [Rank]
FROM [Employees]

SELECT [EmployeeID], [FirstName]
FROM [Employees]
WHERE [FirstName] LIKE 'G%'

