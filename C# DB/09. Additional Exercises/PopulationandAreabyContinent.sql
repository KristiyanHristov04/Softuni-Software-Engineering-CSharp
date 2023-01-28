SELECT  [conts].ContinentName, 
		SUM(CAST([AreaInSqKm] AS BIGINT)) AS [CountriesArea],
		SUM(CAST([Population] AS BIGINT)) AS [CountriesPopulation]
FROM [Continents] AS [conts]
	 JOIN [Countries] AS [c] ON [c].ContinentCode = [conts].ContinentCode
GROUP BY [conts].ContinentName
ORDER BY [CountriesPopulation] DESC