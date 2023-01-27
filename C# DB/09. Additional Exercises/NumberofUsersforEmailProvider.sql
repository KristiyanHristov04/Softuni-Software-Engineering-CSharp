SELECT [Domain],
COUNT(*) AS [Number Of Users]
FROM
	(
	SELECT  [Id],
			[Username],
			[FirstName], 
			[LastName], 
			SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])) AS [Domain]
	FROM [Users]
	) AS [data]
GROUP BY [data].Domain
ORDER BY [Number Of Users] DESC, [Domain] ASC