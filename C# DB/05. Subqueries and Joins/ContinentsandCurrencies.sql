SELECT 
    [ContinentCode],
    [CurrencyCode],
    [CurrencyUsage]
FROM (SELECT
          [ContinentCode],
          [CurrencyCode],
          DENSE_RANK() OVER (PARTITION BY [ContinentCode] ORDER BY COUNT(*) DESC) AS [Ranking],
          COUNT(*) AS [CurrencyUsage]
      FROM [Countries]
      GROUP BY [ContinentCode], [CurrencyCode]) AS [RankedTable]
WHERE [Ranking] = 1 AND [CurrencyUsage] > 1
ORDER BY [ContinentCode], [CurrencyCode]