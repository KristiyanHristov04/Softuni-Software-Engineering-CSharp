--CREATE DATABASE [UniversityDB]

--USE [UniversityDB]

CREATE TABLE [Subjects](
	[SubjectID] INT PRIMARY KEY IDENTITY,
	[SubjectName] VARCHAR(50) NOT NULL
)

CREATE TABLE [Majors](
	[MajorID] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Students](
	[StudentID] INT PRIMARY KEY IDENTITY,
	[StudentNumber] INT NOT NULL,
	[StudentName] VARCHAR NOT NULL,
	[MajorID] INT FOREIGN KEY REFERENCES [Majors]([MajorID])
)

CREATE TABLE [Payments](
	[PaymentID] INT PRIMARY KEY,
	[PaymentDate] DATE NOT NULL,
	[PaymentAmount] DECIMAL(6,2) NOT NULL,
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID])
)

CREATE TABLE [Agenda](
	[StudentID] INT FOREIGN KEY REFERENCES [Students]([StudentID]),
	[SubjectID] INT FOREIGN KEY REFERENCES [Subjects]([SubjectID]),
	PRIMARY KEY ([StudentID], [SubjectID])
)