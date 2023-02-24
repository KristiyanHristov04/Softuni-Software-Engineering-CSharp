SELECT * FROM [Users]
SELECT * FROM [Commits]
SELECT * FROM [Files]

SELECT [u].Username, AVG([f].Size) AS [Size] FROM [Users] AS [u]
JOIN [Commits] AS [c] ON [c].ContributorId = [u].Id
JOIN [Files] AS [f] ON [f].CommitId = [c].Id
GROUP BY [u].Username
ORDER BY [Size] DESC, [u].Username ASC