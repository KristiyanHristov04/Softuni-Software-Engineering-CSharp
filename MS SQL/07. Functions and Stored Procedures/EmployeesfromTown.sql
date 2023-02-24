CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName VARCHAR(50))
AS
	SELECT [e].FirstName,
	[e].LastName
	FROM [Employees] AS [e]
	LEFT JOIN [Addresses] AS [a] ON [a].AddressID =[e].AddressID
	LEFT JOIN [Towns] AS [t] ON [t].TownID = [a].TownID
	WHERE [t].[Name] = @TownName


EXEC [usp_GetEmployeesFromTown] 'Sofia'

--SELECT [e].FirstName,
--[e].LastName
--FROM [Employees] AS [e]
--LEFT JOIN [Addresses] AS [a] ON [a].AddressID =[e].AddressID
--LEFT JOIN [Towns] AS [t] ON [t].TownID = [a].TownID
--WHERE [t].[Name] = 'Sofia'
