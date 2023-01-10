CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees](
	[Id] INT PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(50),
	[Notes] NVARCHAR(50),
)

CREATE TABLE [Customers](
	[AccountNumber] INT PRIMARY KEY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[PhoneNumber] NVARCHAR(10),
	[EmergencyName] NVARCHAR(10),
	[EmergencyNumber] NVARCHAR(10),
	[Notes] NVARCHAR(50),
)

CREATE TABLE [RoomStatus](
	[RoomStatus] INT PRIMARY KEY,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [RoomTypes](
	[RoomType] INT PRIMARY KEY,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [BedTypes](
	[BedType] INT PRIMARY KEY,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Rooms](
	[RoomNumber] INT PRIMARY KEY,
	[RoomType] INT FOREIGN KEY REFERENCES [RoomTypes]([RoomType]),
	[BedType] INT FOREIGN KEY REFERENCES [BedTypes]([BedType]),
	[Rate] INT,
	[RoomStatus] INT FOREIGN KEY REFERENCES [RoomStatus]([RoomStatus]),
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Payments](
	[Id] INT PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[PaymentDate] DATE,
	[AccountNumber] NVARCHAR(50),
	[FirstDateOccupied] DATE,
	[LastDateOccupied] DATE,
	[TotalDays] INT,
	[AmountCharged] INT,
	[TaxRate] INT,
	[TaxAmount] INT,
	[PaymentTotal] INT,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Occupancies](
	[Id] INT PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]),
	[DateOccupied] DATE,
	[AccountNumber] NVARCHAR(50),
	[RoomNumber] NVARCHAR(50),
	[RateApplied] INT,
	[PhoneCharge] INT,
	[Notes] NVARCHAR(50)
)

INSERT INTO [Employees]([Id], [FirstName], [LastName])
	VALUES
	(1, 'John', 'Lennon1'),
	(2, 'John', 'Lennon2'),
	(3, 'John', 'Lennon3')

INSERT INTO [Customers]([AccountNumber], [FirstName], [LastName])
	VALUES
	(1, 'Martin', 'Martinov1'),
	(2, 'Martin', 'Martinov2'),
	(3, 'Martin', 'Martinov3')

INSERT INTO [RoomStatus]([RoomStatus])
	VALUES
	(1),
	(2),
	(3)

INSERT INTO [RoomTypes]([RoomType])
	VALUES
	(1),
	(2),
	(3)

INSERT INTO [BedTypes]([BedType])
	VALUES
	(1),
	(2),
	(3)

INSERT INTO [Rooms]([RoomNumber], [RoomType], [BedType], [RoomStatus])
	VALUES
	(1, 1, 1, 1),
	(2, 2, 2 ,2),
	(3, 3, 3, 3)

INSERT INTO [Payments]([Id], [EmployeeId])
	VALUES
	(1, 3),
	(2, 2),
	(3, 1)

INSERT INTO [Occupancies]([Id], [EmployeeId])
	VALUES
	(1, 3),
	(2, 2),
	(3, 1)