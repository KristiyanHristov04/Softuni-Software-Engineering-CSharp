--CREATE DATABASE TRDB

--USE TRDB

CREATE TABLE [Passports](
	[PassportID] INT PRIMARY KEY,
	[PassportNumber] VARCHAR(20) NOT NULL
)

INSERT INTO [Passports]([PassportID], [PassportNumber])
VALUES
	(101, 'N34FG21B'),
	(102, 'K65LO4R7'),
	(103, 'ZE657QP2')

--SELECT * FROM [Passports]

CREATE TABLE [Persons](
	[PersonID] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(50) NOT NULL,
	[Salary] DECIMAL(7, 2) NOT NULL,
	[PassportID] INT FOREIGN KEY REFERENCES [Passports]([PassportID]) UNIQUE NOT NULL
)

--SELECT * FROM [Persons]

INSERT INTO [Persons]([FirstName], [Salary], [PassportID])
VALUES
	('Roberto', 43300.00, 102),
	('Tom', 56100.00, 103),
	('Yana', 60200.00, 101)