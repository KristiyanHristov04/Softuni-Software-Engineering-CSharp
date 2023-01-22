CREATE PROCEDURE usp_GetHoldersFullName
AS
SELECT CONCAT([FirstName], ' ', [LastName]) AS [FullName]
FROM [AccountHolders]

EXEC usp_GetHoldersFullName