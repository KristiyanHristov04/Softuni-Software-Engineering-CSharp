SELECT [p].PeakName, 
	[m].MountainRange AS [Mountain],
	[c].CountryName,
	[cont].ContinentName 
FROM [Peaks] AS [p]
	JOIN [Mountains] AS [m] ON [m].Id = [p].MountainId
	JOIN [MountainsCountries] AS [mc] ON [mc].MountainId = [m].Id
	JOIN [Countries] AS [c] ON [c].CountryCode = [mc].CountryCode
	JOIN [Continents] AS [cont] ON [cont].ContinentCode = [c].ContinentCode
ORDER BY [p].PeakName ASC, [c].CountryName ASC