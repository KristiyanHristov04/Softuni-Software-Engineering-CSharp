SELECT [data2].FullName, [data2].Email, [data2].Rating FROM
(
	SELECT *, DENSE_RANK() OVER(PARTITION BY [FullName] ORDER BY [Rating] DESC) AS [Rank] FROM
	(
		SELECT  CONCAT([c].FirstName, ' ', [c].LastName) AS [FullName], 
				[c].Email, 
				[bg].Rating
		FROM [Creators] AS [c]
				JOIN [CreatorsBoardgames] AS [cb] ON [c].Id = [cb].CreatorId
				JOIN [Boardgames] AS [bg] ON [cb].BoardgameId = [bg].Id
		WHERE [Email] LIKE '%.com'
	) AS [data]
) AS [data2]
WHERE [data2].[Rank] = 1
ORDER BY [data2].FullName ASC