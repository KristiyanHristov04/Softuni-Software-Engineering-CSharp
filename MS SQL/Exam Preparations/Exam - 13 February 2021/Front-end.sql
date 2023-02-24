--One way to solve the problem
--SELECT [Id], [Name], [Size] FROM
--	(
--		SELECT  [Id],
--				[Name],
--				[Size],
--				SUBSTRING([Name], CHARINDEX('html', [Name]), LEN([Name])) AS [HTML]
--		FROM [Files]
--		WHERE [Size] > 1000
--	)
--	AS [data]
--WHERE [data].HTML = 'html'
--ORDER BY [Size] DESC, [Id], [Name]

--Another way to solve the problem
SELECT Id, Name, Size
FROM Files
WHERE Size > 1000 AND Name LIKE '%html'
ORDER BY Size DESC, Id ASC, Name ASC