UPDATE [Countries]
SET [CountryName] = 'Burma'
WHERE [CountryName] = 'Myanmar'

INSERT INTO [Monasteries]
	VALUES
		('Hanga Abbey',
			(	SELECT [CountryCode]
				FROM [Countries]
				WHERE [CountryName] = 'Tanzania'
			)
		),
		('Myin-Tin-Daik',
			(
				SELECT [CountryCode]
				FROM [Countries]
				WHERE [CountryName] = 'Myanmar'
			)
		)

SELECT  [conts].ContinentName,
		[c].CountryName, 
		COUNT([m].Id) AS [MonasteriesCount]
FROM [Continents] AS [conts]
		LEFT JOIN [Countries] AS [c] ON [c].ContinentCode = [conts].ContinentCode
		LEFT JOIN [Monasteries] AS [m] ON [m].CountryCode = [c].CountryCode
WHERE [c].IsDeleted = 0
GROUP BY [conts].ContinentName, [c].CountryName
ORDER BY [MonasteriesCount] DESC, [c].CountryName