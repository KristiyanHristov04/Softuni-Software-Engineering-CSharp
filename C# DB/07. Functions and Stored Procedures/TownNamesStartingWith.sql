CREATE PROCEDURE usp_GetTownsStartingWith (@Input VARCHAR(50))
AS
SELECT [Name] AS [Town]
FROM [Towns]
WHERE [Name] LIKE @Input + '%'

--EXEC [usp_GetTownsStartingWith] 'b'




