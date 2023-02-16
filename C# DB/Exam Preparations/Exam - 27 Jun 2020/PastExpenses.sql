SELECT JobId, CAST(IIF([data].Total IS NULL, 0.00, [data].Total) AS DECIMAL(18, 2)) AS [Total] FROM
(
	SELECT [j].JobId, SUM([p].Price) AS [Total] FROM [Jobs] AS [j]
	LEFT JOIN [Orders] AS [o] ON [o].JobId = [j].JobId
	 JOIN [OrderParts] AS [op] ON [op].OrderId = [o].OrderId
	 JOIN [Parts] AS [p] ON [p].PartId = [op].PartId
	WHERE [j].[Status] = 'Finished'
	GROUP BY [j].JobId
) AS [data]
ORDER BY [Total] DESC, [data].JobId ASC

---
SELECT [j].JobId, [j].[Status], [op].Quantity AS [OrderedQuantity], [p].Price,
CASE
	WHEN [OrderedQuantity] > 1 THEN [Price] = [Price] * [OrderedQuantity]
	ELSE [Price]
END AS [New Prices]
FROM [Jobs] AS [j]
JOIN [Orders] AS [o] ON [o].JobId = [j].JobId
JOIN [OrderParts] AS [op] ON [op].OrderId = [o].OrderId
JOIN [Parts] AS [p] ON [p].PartId = [op].PartId
WHERE [j].[Status] = 'Finished'
ORDER BY [j].[JobId]



---
SELECT [data3].JobId, IIF([data3].[Total] IS NULL, 0, [data3].[Total]) AS [Total] FROM
(
	SELECT [data2].JobId, SUM([data2].[New Prices]) AS [Total] FROM 
	(
		SELECT [data].JobId,
			CASE
				WHEN [data].OrderedQuantity > 1 THEN [data].Price * [data].OrderedQuantity
				ELSE [data].Price
			END AS [New Prices]
		FROM 
		(
			SELECT [j].JobId, [j].[Status], [op].Quantity AS [OrderedQuantity], [p].Price
			FROM [Jobs] AS [j]
			LEFT JOIN [Orders] AS [o] ON [o].JobId = [j].JobId
			LEFT JOIN [OrderParts] AS [op] ON [op].OrderId = [o].OrderId
			LEFT JOIN [Parts] AS [p] ON [p].PartId = [op].PartId
			WHERE [j].[Status] = 'Finished'
		) AS [data]
	) AS [data2]
	GROUP BY [data2].JobId
) AS [data3]
ORDER BY [data3].[Total] DESC, [data3].JobId ASC