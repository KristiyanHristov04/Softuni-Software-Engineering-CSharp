SELECT [p].FullName, COUNT(*) AS [CountOfAircraft], SUM([fd].TicketPrice) AS [TotalPayed] FROM [Passengers] AS [p]
JOIN [FlightDestinations] AS [fd] ON [fd].PassengerId = [p].Id
GROUP BY [p].FullName
HAVING COUNT(*) >= 2 AND [p].FullName LIKE '_a%'
ORDER BY [p].FullName