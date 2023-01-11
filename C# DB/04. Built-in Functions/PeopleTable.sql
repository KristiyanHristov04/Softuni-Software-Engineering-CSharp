SELECT [Name],
	   [BirthDate],
	   DATEDIFF(YEAR, [BirthDate], GETDATE()) AS [Age In Years],
	   DATEDIFF(MONTH, [BirthDate], GETDATE()) AS [Age in Months],
	   DATEDIFF(DAY, [BirthDate], GETDATE()) AS [Age in Days],
	   DATEDIFF(MINUTE, [BirthDate], GETDATE()) AS [Age in Minutes]
FROM [People]