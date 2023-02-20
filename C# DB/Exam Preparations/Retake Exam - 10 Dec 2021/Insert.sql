INSERT INTO [Passengers]([FullName], [Email])
	SELECT CONCAT([FirstName], ' ', [LastName]) AS [FullName], CONCAT([FirstName], [LastName], '@gmail.com') AS [Email] FROM [Pilots]
	WHERE [Id] BETWEEN 5 AND 15


--Another way
--INSERT INTO Passengers
--SELECT 
--    p.FirstName + ' ' + p.LastName,
--    p.FirstName + p.LastName + '@gmail.com'
--FROM Pilots AS p
--WHERE p.Id BETWEEN 5 AND 15