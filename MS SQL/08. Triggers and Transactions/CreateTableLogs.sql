CREATE TABLE [Logs]
(
	[LogId] INT PRIMARY KEY IDENTITY,
	[AccountId] INT NOT NULL FOREIGN KEY REFERENCES [Accounts]([Id]),
	[OldSum] MONEY NOT NULL,
	[NewSum] MONEY NOT NULL

)

DROP TABLE [Logs]

GO

CREATE TRIGGER tr_OnLogsAddLogRecord
ON [Accounts] FOR UPDATE
AS
BEGIN
	INSERT INTO [Logs] ([AccountId], [OldSum], [NewSum])
	SELECT [i].[Id], [d].[Balance], [i].[Balance]
	  FROM [inserted] AS [i]
	  JOIN [deleted] AS [d]
	    ON [i].[Id] = [d].[Id]

END
