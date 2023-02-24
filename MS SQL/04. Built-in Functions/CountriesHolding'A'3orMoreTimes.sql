SELECT [CountryName], [IsoCode]
FROM [Countries]
WHERE LOWER([CountryName]) LIKE '%a%a%a%'
ORDER BY [IsoCode]