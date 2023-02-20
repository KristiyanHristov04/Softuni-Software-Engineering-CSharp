SELECT [a].Id AS [AircraftId], [a].Manufacturer, [a].FlightHours, COUNT(*) AS [FlightDestinationsCount], ROUND(AVG([fd].TicketPrice), 2) AS [AvgPrice] FROM [FlightDestinations] AS [fd]
JOIN [Aircraft] AS [a] ON [a].Id = [fd].AircraftId
GROUP BY [a].Id, [a].Manufacturer, [a].FlightHours
HAVING COUNT(*) >= 2 
ORDER BY [FlightDestinationsCount] DESC, [a].Id ASC