SELECT [data].LastName, [data].Nationality, [data].Age, [data].PhoneNumber FROM 
(

		SELECT  SUBSTRING([t].[Name], CHARINDEX(' ', [t].[Name]) + 1, LEN([t].[Name])) AS [LastName],
				[t].Nationality, 
				[t].Age, 
				[t].PhoneNumber
		FROM [Tourists] AS [t]
				LEFT JOIN [SitesTourists] AS [st] ON [st].TouristId = [t].Id
				JOIN [Sites] AS [s] ON [s].Id = [st].SiteId
				JOIN [Categories] AS [c] ON [c].Id = [s].CategoryId
		WHERE [c].[Name] = 'History and archaeology'
) AS [data]
GROUP BY [data].LastName, [data].Nationality, [data].Age, [data].PhoneNumber
ORDER BY [LastName] ASC
