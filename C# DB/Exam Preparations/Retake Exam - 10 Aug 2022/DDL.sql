CREATE DATABASE [NationalTouristSitesOfBulgaria]

GO

USE [NationalTouristSitesOfBulgaria]

GO

CREATE TABLE [Categories](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [Locations](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Municipality] VARCHAR(50),
	[Province] VARCHAR(50)
)

CREATE TABLE [Sites](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(100) NOT NULL,
	[LocationId] INT FOREIGN KEY REFERENCES [Locations]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Establishment] VARCHAR(15)
)

CREATE TABLE [Tourists](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Age] INT NOT NULL CHECK([Age] BETWEEN 0 AND 120),
	[PhoneNumber] VARCHAR(20) NOT NULL,
	[Nationality] VARCHAR(30) NOT NULL,
	[Reward] VARCHAR(20)
)

CREATE TABLE [SitesTourists](
	[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]) NOT NULL,
	[SiteId] INT FOREIGN KEY REFERENCES [Sites]([Id]) NOT NULL,
	PRIMARY KEY ([TouristId], [SiteId])
)

CREATE TABLE [BonusPrizes](
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE [TouristsBonusPrizes](
	[TouristId] INT FOREIGN KEY REFERENCES [Tourists]([Id]) NOT NULL,
	[BonusPrizeId] INT FOREIGN KEY REFERENCES [BonusPrizes]([Id]) NOT NULL,
	PRIMARY KEY ([TouristId], [BonusPrizeId])
)
