SELECT  [curr].CurrencyCode, 
		[curr].[Description] AS [Currency], 
		COUNT([c].CountryCode) AS [NumberOfCountries]
FROM [Currencies] AS [curr]
	 LEFT JOIN [Countries] AS [c] ON [c].CurrencyCode = [curr].CurrencyCode
GROUP BY [curr].CurrencyCode, [curr].[Description]
ORDER BY [NumberOfCountries] DESC, [curr].[Description] ASC