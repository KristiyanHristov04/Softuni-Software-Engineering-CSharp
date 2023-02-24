SELECT  [data].AccountId,
		[data].FullName,
		MAX([data].TripLength) AS [LongestTrip],
		MIN([data].TripLength) AS [ShortestTrip]
		FROM
(
	SELECT  [a].Id AS [AccountId],
			CONCAT([a].FirstName, ' ', [a].LastName) AS [FullName],
			[t].ArrivalDate, 
			[t].ReturnDate, 
			[t].CancelDate,
			DATEDIFF(DAY, [t].ArrivalDate, [t].ReturnDate) AS [TripLength]
	FROM [Accounts] AS [a]
		JOIN [AccountsTrips] AS [at] ON [at].AccountId = [a].Id
		JOIN [Trips] AS [t] ON [t].Id = [at].TripId
	WHERE [t].CancelDate IS NULL
	AND [a].MiddleName IS NULL
) AS [data]
GROUP BY [data].AccountId, [data].FullName
ORDER BY [LongestTrip] DESC, [ShortestTrip] ASC