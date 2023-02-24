CREATE DATABASE [WMS]

GO

USE [WMS]

GO

CREATE TABLE [Clients](
	[ClientId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Phone] CHAR(12) NOT NULL
)

CREATE TABLE [Mechanics](
	[MechanicId] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE [Models](
	[ModelId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE,
)

CREATE TABLE [Jobs](
	[JobId] INT PRIMARY KEY IDENTITY,
	[ModelId] INT FOREIGN KEY REFERENCES [Models]([ModelId]) NOT NULL,
	[Status] VARCHAR(11) NOT NULL DEFAULT('Pending')
	CHECK([Status] = 'Pending' OR [Status] = 'In Progress' OR [Status] = 'Finished'),
	[ClientId] INT FOREIGN KEY REFERENCES [Clients]([ClientId]) NOT NULL,
	[MechanicId] INT FOREIGN KEY REFERENCES [Mechanics]([MechanicId]),
	[IssueDate] DATE NOT NULL,
	[FinishDate] DATE
)

CREATE TABLE [Orders](
	[OrderId] INT PRIMARY KEY IDENTITY,
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[IssueDate] DATE,
	[Delivered] BIT NOT NULL DEFAULT(0)
)

CREATE TABLE [Vendors](
	[VendorId] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE [Parts](
	[PartId] INT PRIMARY KEY IDENTITY,
	[SerialNumber] VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	[Price] MONEY NOT NULL CHECK([Price] > 0 AND [Price] <= 9999.99),
	[VendorId] INT FOREIGN KEY REFERENCES [Vendors]([VendorId]) NOT NULL,
	[StockQty] INT NOT NULL DEFAULT(0) CHECK([StockQty] >= 0)
)

CREATE TABLE [OrderParts](
	[OrderId] INT FOREIGN KEY REFERENCES [Orders]([OrderId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	PRIMARY KEY ([OrderId], [PartId]),
	[Quantity] INT NOT NULL DEFAULT(1) CHECK([Quantity] > 0)
)

CREATE TABLE [PartsNeeded](
	[JobId] INT FOREIGN KEY REFERENCES [Jobs]([JobId]) NOT NULL,
	[PartId] INT FOREIGN KEY REFERENCES [Parts]([PartId]) NOT NULL,
	PRIMARY KEY([JobId], [PartId]),
	[Quantity] INT NOT NULL DEFAULT(1) CHECK([Quantity] > 0)
)
