DELETE FROM [TouristsBonusPrizes]
WHERE [BonusPrizeId] = 
(
	SELECT [Id] FROM [BonusPrizes]
	WHERE [Name] = 'Sleeping bag'
)


DELETE FROM [BonusPrizes]
WHERE [Name] = 'Sleeping bag'
