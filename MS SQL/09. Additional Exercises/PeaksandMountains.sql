SELECT * FROM [Peaks]
SELECT * FROM [Mountains]

SELECT [p].PeakName, 
	[m].MountainRange, 
	[p].Elevation 
FROM [Peaks] AS [p]
	JOIN [Mountains] AS [m] ON [m].Id = [p].MountainId
ORDER BY [p].Elevation DESC