USE [Minions]

ALTER TABLE [Minions]
ADD [TownId] INT FOREIGN KEY REFERENCES [Towns]([Id])

SELECT * FROM [Minions]