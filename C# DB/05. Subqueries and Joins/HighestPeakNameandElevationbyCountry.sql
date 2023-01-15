SELECT TOP (5) [Country],
               CASE
                    WHEN [PeakName] IS NULL THEN '(no highest peak)'
                    ELSE [PeakName]
               END AS [Highest Peak Name],
               CASE
                    WHEN [Elevation] IS NULL THEN 0
                    ELSE [Elevation]
               END AS [Highest Peak Elevation],
               CASE
                    WHEN [MountainRange] IS NULL THEN '(no mountain)'
                    ELSE [MountainRange]
               END AS [Mountain]          
               FROM (
                       SELECT [c].[CountryName] AS [Country],
                              [m].[MountainRange],
                              [p].[PeakName],
                              [p].[Elevation],
                              DENSE_RANK() OVER(PARTITION BY [c].[CountryName] ORDER BY [p].[Elevation] DESC) 
                           AS [PeakRank]
                         FROM [Countries] AS [c]
                    LEFT JOIN [MountainsCountries] AS [mc]
                           ON [mc].[CountryCode] = [c].[CountryCode]
                    LEFT JOIN [Mountains] AS [m]
                           ON [mc].[MountainId] = [m].[Id]
                    LEFT JOIN [Peaks] AS [p]
                           ON [p].[MountainId] = [m].[Id]
                   ) AS [PeakRankingQuery]
        WHERE [PeakRank] = 1
     ORDER BY [Country], [Highest Peak Name]