SELECT * FROM [Clients]
SELECT * FROM [Cigars]
SELECT * FROM [ClientsCigars]

SELECT [c].LastName, AVG([s].[Length]) AS [CigarLength], CEILING(AVG([s].RingRange)) AS [CigarRingRange] FROM [Clients] AS [c]
JOIN [ClientsCigars] AS [cc] ON [cc].ClientId = [c].Id
JOIN [Cigars] AS [cigar] ON [cigar].Id = [cc].CigarId
JOIN [Sizes] AS [s] ON [s].Id = [cigar].SizeId
GROUP BY [c].LastName
ORDER BY [CigarLength] DESC