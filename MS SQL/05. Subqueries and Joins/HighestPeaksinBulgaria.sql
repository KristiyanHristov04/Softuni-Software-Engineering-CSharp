SELECT [mc].[CountryCode], [m].MountainRange, [p].PeakName, [p].Elevation FROM [Mountains] AS [m]
JOIN [Peaks] AS [p] ON [p].MountainId = [m].Id
JOIN [MountainsCountries] AS [mc] ON [mc].MountainId = [p].MountainId
WHERE [p].Elevation > 2835 AND [mc].CountryCode = 'BG'
ORDER BY [p].Elevation DESC
