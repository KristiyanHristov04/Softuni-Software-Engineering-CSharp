CREATE OR ALTER FUNCTION ufn_CalculateFutureValue (@Sum DECIMAL(9, 4), @YearRate FLOAT, @Years INT)
RETURNS DECIMAL(8, 4)
BEGIN
	DECLARE @Result DECIMAL(8, 4)
	BEGIN
		SET @Result = @Sum * POWER(1 + (@YearRate * 100) / 100, @Years)
	END
	RETURN @Result
END

EXEC ufn_CalculateFutureValue 1000, 0.1, 5

SELECT [dbo].ufn_CalculateFutureValue (123.12, 0.1, 5) AS [Result]