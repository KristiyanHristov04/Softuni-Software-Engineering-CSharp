SELECT [p].FirstName, [p].LastName, [a].Manufacturer, [a].Model, [a].FlightHours FROM [Pilots] AS [p]
JOIN [PilotsAircraft] AS [pa] ON [pa].PilotId = [p].Id
JOIN [Aircraft] AS [a] ON [a].Id = [pa].AircraftId
WHERE [a].FlightHours < 304 AND [a].FlightHours IS NOT NULL
ORDER BY [a].FlightHours DESC, [p].FirstName ASC
