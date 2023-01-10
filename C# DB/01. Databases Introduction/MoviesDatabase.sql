CREATE DATABASE [Movies]

USE [Movies]

CREATE TABLE [Directors](
	[Id] INT PRIMARY KEY,
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Genres](
	[Id] INT PRIMARY KEY,
	[GenreName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(50)
)

CREATE TABLE [Movies](
	[Id] INT PRIMARY KEY,
	[Title] NVARCHAR(50) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]),
	[CopyrightYear] DATE,
	[Length] NVARCHAR(20),
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]),
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]),
	[Rating] SMALLINT,
	[Notes] NVARCHAR(50)
)

INSERT INTO [Categories]([Id], [CategoryName])
	VALUES
	(1, 'Action'),
	(2, 'Comedy'),
	(3, 'Fantasy'),
	(4, 'Adventure'),
	(5, 'Horror')

INSERT INTO [Directors]([Id], [DirectorName])
	VALUES
	(1, 'John'),
	(2, 'Fury'),
	(3, 'Martin'),
	(4, 'Tom'),
	(5, 'Eddy')

INSERT INTO [Genres]([Id], [GenreName])
	VALUES
	(1, 'Best Audio'),
	(2, 'Best Vibes'),
	(3, 'Something1'),
	(4, 'Something2'),
	(5, 'Something3')

INSERT INTO [Movies]([Id], [Title], [DirectorId], [CategoryId], [GenreId])
	VALUES
	(1, 'LOTR', 2, 1, 1),
	(2, 'LOTR', 3, 5, 2),
	(3, 'LOTR', 4, 4, 3),
	(4, 'LOTR', 5, 3, 4),
	(5, 'LOTR', 1, 2, 5)

SELECT * FROM [Categories]
SELECT * FROM [Directors]
SELECT * FROM [Genres]
SELECT * FROM [Movies]