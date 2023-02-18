SELECT  [Id], FORMAT([JourneyStart], 'dd/MM/yyyy') AS [JourneyStart],
		FORMAT([JourneyEnd], 'dd/MM/yyyy') AS [JourneyEnd]
		FROM [Journeys]
 WHERE [Purpose] = 'Military'
 ORDER BY [JourneyStart]