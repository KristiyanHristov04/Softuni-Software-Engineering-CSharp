SELECT * FROM [Clients]
SELECT * FROM [Addresses]
SELECT * FROM [Cigars]

SELECT [FullName],  [Country], [ZIP], CONCAT('$', MAX([PriceForSingleCigar])) AS [CigarPrice] FROM
				(
					SELECT CONCAT([c].FirstName, ' ', [c].[LastName]) AS [FullName],
					[a].Country,
					[ZIP], ISNUMERIC([ZIP]) AS [DigitsOnlyZipCodes],
					[cigars].PriceForSingleCigar
					FROM [Addresses] AS [a]
					JOIN [Clients] AS [c] ON [c].AddressId = [a].Id
					JOIN [ClientsCigars] AS [cc] ON [cc].ClientId = [c].Id
					JOIN [Cigars] AS [cigars] ON [cigars].Id = [cc].CigarId
				) AS [data]
WHERE [DigitsOnlyZipCodes] = 1
GROUP BY [FullName], [Country], [ZIP]
ORDER BY [FullName]

