SELECT TOP(5) [CigarName], [PriceForSingleCigar], [ImageURL] FROM	(
					SELECT * FROM [Cigars]
					WHERE [SizeId] IN   (
										SELECT [Id] FROM [Sizes]
										WHERE [Length] >= 12
									)
					AND ([CigarName] LIKE '%CI%' OR [PriceForSingleCigar] > 50)
				)
				AS [data]
WHERE [SizeId] IN   (
						SELECT [Id] FROM [Sizes]
						WHERE [RingRange] > 2.55
					)
ORDER BY [CigarName] ASC, [PriceForSingleCigar] DESC



