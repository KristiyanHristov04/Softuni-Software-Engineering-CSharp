SELECT * FROM [Clients]
SELECT * FROM [Cigars]
SELECT * FROM [ClientsCigars]

SELECT [c].FirstName, COUNT([cigar].Id) FROM [Clients] AS [c]
JOIN [ClientsCigars] AS [cc] ON [cc].ClientId = [c].Id
JOIN [Cigars] AS [cigar] ON [cigar].Id = [cc].CigarId
GROUP BY [c].FirstName
HAVING [c].FirstName = 'Betty'

GO

CREATE FUNCTION udf_ClientWithCigars (@name NVARCHAR(30))
RETURNS INT
AS 
	BEGIN 
		DECLARE @numberOfCigars INT = 
										(
											SELECT COUNT([cigar].Id) FROM [Clients] AS [c]
											JOIN [ClientsCigars] AS [cc] ON [cc].ClientId = [c].Id
											JOIN [Cigars] AS [cigar] ON [cigar].Id = [cc].CigarId
											GROUP BY [c].FirstName
											HAVING [c].FirstName = @name
										)
		IF (@numberOfCigars IS NULL)
		BEGIN
			SET @numberOfCigars = 0
		END
		RETURN @numberOfCigars
	END

GO

SELECT dbo.udf_ClientWithCigars('Jason')