SELECT  [Id],
		CONCAT([c].FirstName, ' ', [c].LastName) AS [CreatorName], 
		[c].Email FROM [Creators] AS [c]
		LEFT JOIN [CreatorsBoardgames] AS [cb] ON [c].Id = [cb].CreatorId
WHERE [BoardgameId] IS NULL