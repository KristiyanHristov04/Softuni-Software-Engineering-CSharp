CREATE DATABASE [Relations]

USE [Relations]


--One-To-One -> relationship
CREATE TABLE [Cars](
	[CarID] INT PRIMARY KEY IDENTITY,
	[Model] VARCHAR(50) NOT NULL
)

INSERT INTO [Cars]([Model])
VALUES
	('BMW'),
	('Mercedes'),
	('Toyota')

SELECT * FROM [Cars]

CREATE TABLE [People](
	[PeopleID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[CarID] INT FOREIGN KEY REFERENCES [Cars]([CarID]) UNIQUE NOT NULL 
)

INSERT INTO [People]([Name], [CarID])
VALUES
	('Ivan', 2)

SELECT * FROM [People]

INSERT INTO [People]([Name], [CarID])
VALUES
	('Marto', 1),
	('Georgi', 3)

--One-To-Many -> relationship

CREATE TABLE [Customers](
	[CustomerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL
)

INSERT INTO [Customers]([Name] ,[Age])
VALUES
	('Kristiyan', 18),
	('Ivan', 15)

SELECT * FROM [Customers]

CREATE TABLE [Accounts](
	[AccountID] INT PRIMARY KEY IDENTITY,
	[CreatedOn] DATE DEFAULT('01/01/2001') NOT NULL,
	[CustomerID] INT FOREIGN KEY REFERENCES [Customers]([CustomerID]) NOT NULL
)

INSERT INTO [Accounts]([CreatedOn], [CustomerID])
VALUES
	--('02/07/2004', 1),
	('02/07/2005', 1)

SELECT * FROM [Accounts]

----Many-To-Many -> relationship

CREATE TABLE [Racers](
	[RacerID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT DEFAULT(18) NOT NULL
)

INSERT INTO [Racers]([Name], [Age])
VALUES
	('Stefan', 19),
	('Martin', DEFAULT),
	('Gosho', 22),
	('Joro', 37),
	('Robert', 24)

SELECT * FROM [Racers]

CREATE TABLE [Races](
	[RaceID] INT PRIMARY KEY IDENTITY,
	[RaceName] VARCHAR(50) NOT NULL
)

INSERT INTO [Races]([RaceName])
VALUES
	('Sofia race'),
	('Buchurest race')

SELECT * FROM [Races]

CREATE TABLE [RacersRaces](
	[RacerID] INT FOREIGN KEY REFERENCES [Racers]([RacerID]) NOT NULL,
	[RaceID] INT FOREIGN KEY REFERENCES [Races]([RaceID]) NOT NULL,
	PRIMARY KEY ([RacerID], [RaceID])
)

SELECT * FROM [RacersRaces]

INSERT INTO [RacersRaces]([RacerID], [RaceID])
VALUES
	(1, 1),
	(2, 1),
	(4, 1),
	(1, 2),
	(2, 2)

	
