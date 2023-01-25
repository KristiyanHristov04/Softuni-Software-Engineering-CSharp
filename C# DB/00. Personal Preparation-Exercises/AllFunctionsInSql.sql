CREATE DATABASE [BuiltIn]

USE [BuiltIn]

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Age] INT NOT NULL,
	[BirthDate] DATETIME DEFAULT('2023/01/06') NOT NULL 
)


INSERT INTO [Customers]([FirstName], [LastName], [Age])
VALUES
	--('Kristiyan', 'Hristov', 18, '2004/04/23')
	('Ivan', 'Shkumbata', 44)

UPDATE [Customers]
SET [FirstName] = 'Dimitar', [LastName] = 'Dimitrov', [Age] = 23
WHERE [CustomerID] = 1

SELECT * FROM [Customers]

DELETE FROM [Customers]
WHERE [CustomerID] = 3

ALTER TABLE [Customers]
ADD [Gender] CHAR(1) DEFAULT ('n')

UPDATE [Customers]
SET [Gender] = 'm'
WHERE [CustomerID] IN (1, 2)

CREATE TABLE [Items](
	[ItemID] INT PRIMARY KEY IDENTITY(100, 1),
	[ItemName] NVARCHAR(50) NOT NULL
)

INSERT INTO [Items]([ItemName])
VALUES
	('Krem Nivea'),
	('Krem Zdrave'),
	('Krem indiisko orehche'),
	('Sladka baklavica ot lelq Dimitrica')

SELECT * FROM [Items]
SELECT * FROM [Customers]

ALTER TABLE [Customers]
ADD [ItemID] INT FOREIGN KEY REFERENCES [Items]([ItemID])

UPDATE [Customrs]
SET [ItemID] = 102
WHERE [CustomerID] IN (1, 2)


SELECT * FROM [Customers]

--BUILT-IN FUNCTIONS
--(String Functions)

SELECT [FirstName], LEN([FirstName]) AS [NameLength]
FROM [Customers]

SELECT [FirstName], SUBSTRING([FirstName], 1, 4) AS [NameSubstring]
FROM [Customers]

SELECT [FirstName], CHARINDEX('t', [FirstName]) AS [CharIndex]
FROM [Customers]

SELECT [FirstName], CONCAT([FirstName], ' is my name.') AS [ConcatString]
FROM [Customers]

SELECT [FirstName], CONCAT_WS('&', [FirstName], 'John are best friends.') AS [Concat_WS]
FROM [Customers]

SELECT [FirstName], DATALENGTH([FirstName]) AS [DataLengthString]
FROM [Customers]

SELECT [BirthDate], FORMAT([BirthDate], 'd', 'bg-BG') AS [FormatBirthDate]
FROM [Customers]

SELECT [FirstName], LEFT([FirstName], LEN([FirstName]) - 2) AS [LeftStringLength]
FROM [Customers]

SELECT [FirstName], RIGHT([FirstName], 2) AS [RightStringLength]
FROM [Customers]

SELECT [FirstName], LOWER([FirstName]) AS [FirstNameLower]
FROM [Customers]

SELECT [FirstName], UPPER([FirstName]) AS [FirstNameUpper]
FROM [Customers]

SELECT '     John' AS [WithoutLeftTrim], LTRIM('     John') AS [WithLeftTrim]

SELECT 'John     ' AS [WithoutRightTrim], RTRIM('John     ') AS [WithRightTrim]

SELECT '      John     ' AS [WithoutTrim], TRIM('      John     ') AS [WithTrim]

SELECT 'Kocho' AS [Name], REPLACE('Kocho', 'K', 'B') AS [ReplacedName]

SELECT 'SoftUni' AS [NotReversedWord], REVERSE('SoftUni') AS [ReversedWord]

--(Math Functions)

SELECT -245 AS [NegativeNumber], ABS(-245) AS [PositiveNumberABS]

SELECT AVG(CAST([Age] AS FLOAT)) AS [AverageAge]
FROM [Customers]

SELECT 25.45 AS [NotCeilingNumber], CEILING(25.45) AS [CeilingNumber]

SELECT 25.45 AS [NotFloorNumber], FLOOR(25.45) AS [FloorNumber]

SELECT COUNT(*) AS [AllRows]
FROM [Items]

SELECT MAX([Age]) AS [BiggestAge]
FROM [Customers]

SELECT MIN([Age]) AS [SmallestAge]
FROM [Customers]

SELECT PI() AS [PiNumber]

SELECT POWER(3, 2) AS [3ToThePowerOf2]

SELECT RAND() AS [RandomNumber]

SELECT SUM(25 * 2 + 16 - 8) AS [Sum]
