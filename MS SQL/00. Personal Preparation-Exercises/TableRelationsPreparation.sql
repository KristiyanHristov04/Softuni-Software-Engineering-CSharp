CREATE DATABASE [TableRelationsPreparation]

GO

--One-To-Many Relationship
CREATE TABLE [Countries](
	[CountryID] INT PRIMARY KEY IDENTITY,
	[CountryName] VARCHAR(50) NOT NULL
)

GO

INSERT INTO [Countries]([CountryName])
	VALUES	
		('Bulgaria'),
		('Germany'),
		('Serbia'),
		('Greece')

GO

CREATE TABLE [Towns](
	[TownID] INT PRIMARY KEY IDENTITY,
	[TownName] VARCHAR(50) NOT NULL,
	[CountryID] INT FOREIGN KEY REFERENCES [Countries]([CountryID]) NOT NULL
)

GO

INSERT INTO [Towns]([TownName], [CountryID])
	VALUES
		('Sofia', 1),
		('Varna', 1),
		('Munich', 2),
		('Athens', 4)

GO

--Many-To-Many Relationship
CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentName] VARCHAR(50) NOT NULL
)

GO

CREATE TABLE [Courses](
	[CourseID] INT PRIMARY KEY IDENTITY,
	[CourseName] VARCHAR(50) NOT NULL
)

GO

INSERT INTO [Students]([StudentName])
	VALUES
		('Kristiyan'),
		('Ivan'),
		('Martin'),
		('George')

GO

INSERT INTO [Courses]([CourseName])
	VALUES		
		('C# Basics'),
		('C# Fundamentals')

GO

SELECT * FROM [Students]
SELECT * FROM [Courses]

GO

CREATE TABLE [StudentsCourses](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]) NOT NULL,
	[CourseID] INT FOREIGN KEY REFERENCES [Courses]([CourseID]) NOT NULL,
	PRIMARY KEY ([StudentID], [CourseID]) --Composite Primary Key
)

GO

INSERT INTO [StudentsCourses]
	VALUES
		(1, 1),
		(2, 1),
		(3, 1),
		(4, 2)

GO

SELECT * FROM [StudentsCourses]
SELECT * FROM [Students]
SELECT * FROM [Courses]

GO

--One-To-One Relationship
CREATE TABLE [Drivers](
	[DriverID] INT PRIMARY KEY IDENTITY(100, 1),
	[DriverName] VARCHAR(50) NOT NULL
)

GO

INSERT INTO [Drivers]([DriverName])
	VALUES
		('Sasho'),
		('Momchil'),
		('Kolio')

SELECT * FROM [Drivers]

GO

CREATE TABLE [Cars](
	[CarID] INT PRIMARY KEY IDENTITY,
	[Model] VARCHAR(50) NOT NULL,
	[DriverID] INT FOREIGN KEY REFERENCES [Drivers]([DriverID]) NOT NULL UNIQUE 
)

GO

INSERT INTO [Cars]([Model], [DriverID])
	VALUES	
		('Renault', 101),
		('Lambo', 102)

GO

SELECT * FROM [Drivers]
SELECT * FROM [Cars]

GO

--JOINS
SELECT * FROM [Towns]
SELECT * FROM [Countries]

GO

--Inner Join
SELECT [t].TownName, [c].CountryName FROM [Towns] AS [t]
JOIN [Countries] AS [c] ON [c].CountryID =[t].CountryID

GO

--Right/Left Join
SELECT [t].TownName, [c].CountryName FROM [Towns] AS [t]
RIGHT JOIN [Countries] AS [c] ON [c].CountryID =[t].CountryID

GO

--CASCADE DELETE
CREATE TABLE [Products](
	[ProductID] INT PRIMARY KEY IDENTITY(100, 1),
	[ProductName] VARCHAR(50) NOT NULL
)

GO

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[CustomerName] VARCHAR(50) NOT NULL,
	[ProductID] INT FOREIGN KEY REFERENCES [Products]([ProductID]) ON DELETE CASCADE NOT NULL
)

INSERT INTO [Products]([ProductName])
	VALUES	
		('Cheese'),
		('Bread'),
		('Milk')

GO

INSERT INTO [Customers]([CustomerName], [ProductID])
	VALUES	
		('Kristiyan', 100),
		('Ivan', 100),
		('Maria', 101)

SELECT * FROM [Products]
SELECT * FROM [Customers]

DELETE FROM [Products]
WHERE [ProductID] = 100
