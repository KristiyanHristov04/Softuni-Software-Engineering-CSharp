USE [Geography]

SELECT * FROM [Peaks]

SELECT * FROM [Mountains]

SELECT [Mountains].MountainRange, [Peaks].PeakName, [Peaks].Elevation
FROM [Mountains]
JOIN [Peaks] ON [Mountains].Id = [Peaks].[MountainId]
WHERE [Mountains].[MountainRange] = 'Rila'
ORDER BY [Peaks].Elevation DESC