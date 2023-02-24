CREATE FUNCTION udf_GetCost (@jobId INT)
RETURNS DECIMAL(18, 2)
AS
BEGIN
	DECLARE @price DECIMAL(18, 2) =
	(
		SELECT SUM([data2].[NewPrice]) AS [Result] FROM 
		(
			SELECT  [data].JobId,
				CASE
					WHEN [data].OrderedParts > 1 THEN [Price] * [data].[OrderedParts]
					ELSE [data].Price
				END AS [NewPrice]
			FROM
			(
				SELECT [j].JobId, [op].Quantity AS [OrderedParts], [p].Price FROM [Jobs] AS [j]
				JOIN [Orders] AS [o] ON [o].JobId = [j].JobId
				JOIN [OrderParts] AS [op] ON [op].OrderId = [o].OrderId
				JOIN [Parts] AS [p] ON [op].PartId = [p].PartId
				WHERE [j].JobId = @jobId
			) AS [data]
		) AS [data2]
		GROUP BY [data2].JobId
	)
	IF (@price IS NULL)
	BEGIN
		SET @price = 0
	END
	RETURN @price
END

GO

SELECT [dbo].udf_GetCost (111)
