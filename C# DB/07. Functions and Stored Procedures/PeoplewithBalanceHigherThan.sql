CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@Number MONEY)
AS
	SELECT [ah].[FirstName], [ah].[LastName]
	FROM 
	(
	SELECT [AccountHolderId], SUM([Balance]) AS [TotalBalance] FROM [Accounts]
	GROUP BY [AccountHolderId]
	)
	AS [data]
JOIN [AccountHolders] AS [ah] ON [data].AccountHolderId = [ah].Id
WHERE [data].TotalBalance > @Number
ORDER BY [ah].FirstName, [ah].LastName

EXEC usp_GetHoldersWithBalanceHigherThan 100000


SELECT * FROM [Accounts]
SELECT * FROM [AccountHolders]