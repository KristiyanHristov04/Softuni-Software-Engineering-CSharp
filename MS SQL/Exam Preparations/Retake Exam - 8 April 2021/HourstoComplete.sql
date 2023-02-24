CREATE FUNCTION udf_HoursToComplete (@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
	BEGIN
		IF @StartDate IS NULL OR @EndDate IS NULL
		BEGIN
			RETURN 0
		END
		DECLARE @hoursToComplete INT =
		(
			DATEDIFF(HOUR, @StartDate, @EndDate)
		)
		RETURN @hoursToComplete
	END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
FROM Reports
