CREATE FUNCTION udf_FlightDestinationsByEmail (@email VARCHAR(50))
RETURNS INT
AS
	BEGIN
		DECLARE @countOfFlightDestinations INT = 
		(
			SELECT COUNT(*) AS [FlightDestinationsCount] FROM [Passengers] AS [p]
			JOIN [FlightDestinations] AS [fd] ON [fd].PassengerId = [p].Id
			GROUP BY [p].Id, [p].Email
			HAVING [p].Email = @email
		)
		IF (@countOfFlightDestinations IS NULL)
		BEGIN
			SET @countOfFlightDestinations = 0
		END
		RETURN @countOfFlightDestinations
	END

GO

SELECT dbo.udf_FlightDestinationsByEmail ('PierretteDunmuir@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('Montacute@gmail.com')

SELECT dbo.udf_FlightDestinationsByEmail('MerisShale@gmail.com')