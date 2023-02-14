SELECT CONCAT([FirstName], ' ', [LastName]) AS [Available] FROM Mechanics
WHERE [MechanicId] NOT IN
(
		SELECT [MechanicId] FROM 
		(
			SELECT [MechanicId], [Status], DENSE_RANK() OVER (ORDER BY [Status]) AS [data] FROM [Jobs]
			GROUP BY [MechanicId], [Status]
		) AS [subquery]
		WHERE [data] > 1 AND [MechanicId] IS NOT NULL
)
