CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount (@accountId INT, @yearlyInterestRate FLOAT)
AS
   SELECT [a].[Id] AS [Account Id], 
		  [ah].[FirstName] AS [First Name], 
		  [ah].[LastName] AS [Last Name], 
		  [a].[Balance] AS [Current Balance], 
		  [dbo].[ufn_CalculateFutureValue]([a].Balance, @yearlyInterestRate, 5) 
	   AS [Balance in 5 years]
	 FROM [AccountHolders] AS [ah]
LEFT JOIN [Accounts] AS [a]
	   ON [ah].[Id] = [a].[AccountHolderId]
	WHERE [a].[Id] = @accountId

GO

EXECUTE [dbo].[usp_CalculateFutureValueForAccount] 1, 0.1






SELECT * FROM [AccountHolders]
SELECT * FROM [Accounts]