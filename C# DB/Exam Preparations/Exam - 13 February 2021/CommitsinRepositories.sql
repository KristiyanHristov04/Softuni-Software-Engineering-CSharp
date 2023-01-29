SELECT TOP(5) 
		[r].Id,
		[r].[Name],
		COUNT(*) AS [Commits]
		FROM [Commits] AS [c]
	JOIN [Repositories] AS [r] ON [r].Id = [c].RepositoryId
	JOIN [RepositoriesContributors] AS [rc] ON [rc].RepositoryId = [r].Id
GROUP BY [r].Id, [r].[Name]
ORDER BY [Commits] DESC, [r].[Id] ASC, [r].[Name] ASC