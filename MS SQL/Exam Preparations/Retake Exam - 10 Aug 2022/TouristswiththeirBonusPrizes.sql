SELECT [t].[Name], [t].Age, [t].PhoneNumber, [t].Nationality,
CASE
	WHEN [bp].[Name] IS NULL THEN '(no bonus prize)'
	ELSE [bp].[Name]
END AS [Reward]
FROM [Tourists] AS [t]
LEFT JOIN [TouristsBonusPrizes] AS [tbp] ON [tbp].TouristId = [t].Id
LEFT JOIN [BonusPrizes] AS [bp] ON [bp].Id = [tbp].BonusPrizeId
ORDER BY [t].[Name]