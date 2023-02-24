SELECT
    [p].PartId,
    [p].[Description],
    SUM([pn].Quantity) AS [Required],
    SUM([p].StockQty) AS [InStock],
    ISNULL(SUM([t].Quantity), 0) AS [Ordered]
FROM [Parts] AS [p]
LEFT JOIN [PartsNeeded] AS pn ON [p].PartId = [pn].PartId
LEFT JOIN [Jobs] AS [j] ON [pn].JobId = [j].JobId
LEFT JOIN
    (
        SELECT [PartId], [Quantity]       
        FROM [Orders] AS [o]
        JOIN [OrderParts] AS [op] ON [o].OrderId = [op].OrderId
        WHERE [o].Delivered = 0    
    ) AS [t] ON [p].PartId = [t].PartId
WHERE [j].[Status] <> 'Finished'
GROUP BY [p].PartId, [p].[Description]
HAVING SUM([pn].Quantity) > SUM([p].StockQty) + ISNULL(SUM([t].Quantity), 0)
ORDER BY [p].PartId ASC