SELECT * FROM [Tastes]
SELECT * FROM [Cigars]

GO

CREATE PROCEDURE usp_SearchByTaste (@taste VARCHAR(20))
AS
	BEGIN
		SELECT  [c].[CigarName],
				CONCAT('$', [c].[PriceForSingleCigar]) AS [Price],
				[t].[TasteType], 
				[b].BrandName, 
				CONCAT([s].[Length], ' cm') AS [CigarLength], 
				CONCAT([s].RingRange, ' cm') AS [CigarRingRange]
		FROM [Cigars] AS [c]
				JOIN [Tastes] AS [t] ON [t].Id = [c].TastId
				JOIN [Brands] AS [b] ON [b].Id = [c].BrandId
				JOIN [Sizes] AS [s] ON [s].Id = [c].SizeId
		WHERE [c].TastId =  (
								SELECT [Id] FROM [Tastes]
								WHERE [TasteType] = @taste
							)
		ORDER BY [CigarLength] ASC, [CigarRingRange] DESC
	END

EXEC usp_SearchByTaste 'Woody'

