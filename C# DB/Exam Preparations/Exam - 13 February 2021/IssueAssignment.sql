SELECT [i].Id, CONCAT([u].Username, ' : ', [i].Title) FROM [Issues] AS [i]
JOIN [Users] AS [u] ON [u].Id = [i].AssigneeId
ORDER BY [i].Id DESC, [i].AssigneeId ASC