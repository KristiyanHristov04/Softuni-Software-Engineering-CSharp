CREATE DATABASE [CarRental]

USE [CarRental]

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] INT DEFAULT(0),
	[WeeklyRate] INT DEFAULT(0),
	[MonthlyRate] INT DEFAULT(0),
	[WeekendRate] INT DEFAULT(0)
)

CREATE TABLE [Cars](
	[Id] INT PRIMARY KEY,
	[PlateNumber] NVARCHAR(10) NOT NULL,
	[Manufacturer] NVARCHAR(5),
	[Model] NVARCHAR(10),
	[CarYear] DATE,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Doors] INT,
	[Picture] VARBINARY(MAX),
	[Condition] NVARCHAR(50),
	[Available] BIT
)

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(10),
	[Notes] NVARCHAR(50),
)

CREATE TABLE [Customers](
	[Id] INT PRIMARY KEY,
	[DriverLicenseNumber] NVARCHAR(50) NOT NULL,
	[FullName] NVARCHAR(50) NOT NULL,
	[Adress] NVARCHAR(50),
	[City] NVARCHAR(50),
	[ZIPCode] NVARCHAR(50),
	[Notes] NVARCHAR(50),
)

CREATE TABLE [RentalOrders](
	[Id] INT PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]),
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]),
	[TankLevel] INT,
	[KilometrageStart] INT,
	[KilometrageEnd] INT,
	[TotalKilometrage] INT,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[TotalDays] INT,
	[RateApplied] BIT,
	[TaxRate] INT,
	[OrderStatus] NVARCHAR(10),
	[Notes] NVARCHAR(50)
)

INSERT INTO [Categories]([Id], [CategoryName])
	VALUES
	(1, 'Tejko'),
	(2, 'Leko'),
	(3, 'Sredno')

INSERT INTO [Cars]([Id], [PlateNumber], [CategoryId])
	VALUES
	(1, 'EB1022AK', 3),
	(2, 'EB1222AK', 1),
	(3, 'EB1032AK', 2)

INSERT INTO [Employees]([Id], [FirstName], [LastName])
	VALUES
	(1, 'Ivan', 'Ivanov'),
	(2, 'Petur', 'Ivanov'),
	(3, 'Georgi', 'Ivanov')

INSERT INTO [Customers]([Id], [DriverLicenseNumber], [FullName])
	VALUES
	(3, '5674411212', 'Ivan Ivanov'),
	(2, '5674341212', 'Petar Ivanov'),
	(1, '5674412512', 'Georgi Ivanov')

INSERT INTO [RentalOrders]([Id], [EmployeeId], [CustomerId], [CarId])
	VALUES
	(3, 1, 1, 3),
	(1, 3, 2, 1),
	(2, 2, 3, 2)

SELECT * FROM [Categories]
SELECT * FROM [Cars]
SELECT * FROM [Employees]
SELECT * FROM [Customers]
SELECT * FROM [RentalOrders]