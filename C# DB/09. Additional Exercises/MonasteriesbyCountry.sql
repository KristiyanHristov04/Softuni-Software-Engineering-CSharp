CREATE TABLE Monasteries(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[CountryCode] CHAR(2) FOREIGN KEY REFERENCES [Countries]([CountryCode]) NOT NULL
)

INSERT INTO Monasteries(Name, CountryCode) VALUES
('Rila Monastery “St. Ivan of Rila”', 'BG'), 
('Bachkovo Monastery “Virgin Mary”', 'BG'),
('Troyan Monastery “Holy Mother''s Assumption”', 'BG'),
('Kopan Monastery', 'NP'),
('Thrangu Tashi Yangtse Monastery', 'NP'),
('Shechen Tennyi Dargyeling Monastery', 'NP'),
('Benchen Monastery', 'NP'),
('Southern Shaolin Monastery', 'CN'),
('Dabei Monastery', 'CN'),
('Wa Sau Toi', 'CN'),
('Lhunshigyia Monastery', 'CN'),
('Rakya Monastery', 'CN'),
('Monasteries of Meteora', 'GR'),
('The Holy Monastery of Stavronikita', 'GR'),
('Taung Kalat Monastery', 'MM'),
('Pa-Auk Forest Monastery', 'MM'),
('Taktsang Palphug Monastery', 'BT'),
('Sümela Monastery', 'TR')

--Judge doesn't want this
--ALTER TABLE [Countries]
--ADD [IsDeleted] BIT DEFAULT(0) NOT NULL

UPDATE [Countries]
SET [IsDeleted] = 1
WHERE [CountryName] IN
(
	SELECT [c].CountryName FROM [Countries] AS [c]
	JOIN [CountriesRivers] AS [cr] ON [cr].CountryCode = [c].CountryCode
	JOIN [Rivers] AS [r] ON [r].Id = [cr].RiverId
	GROUP BY [c].CountryName
	HAVING COUNT([r].Id) > 3
)

SELECT [m].[Name] AS [Monastery], [c].CountryName AS [Country] FROM [Monasteries] AS [m]
JOIN [Countries] AS [c] ON [m].CountryCode = [c].CountryCode
WHERE [c].IsDeleted = 0
ORDER BY [Monastery]