CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(255)
AS
	BEGIN
		DECLARE @result VARCHAR(255) =
		(
			SELECT CONCAT('Room ', [data].[Id], ': ', [data].[Type], ' (', [data].Beds, ' beds', ') ',  '- ',  '$', [data].RoomPrice) FROM
			(
				SELECT TOP(1) [r].Id, ([h].BaseRate + [r].Price) * @People AS [RoomPrice], [r].[Type], [r].Beds, [t].ArrivalDate, [t].ReturnDate FROM [Rooms] AS [r]
				JOIN [Hotels] AS [h] ON [h].Id = [r].HotelId
				JOIN [Trips] AS [t] ON [t].RoomId = [r].Id
				WHERE [r].HotelId = @HotelId AND [r].Beds >= @People AND [r].Id NOT IN
				(
					  SELECT RoomId FROM Trips
					  WHERE @Date BETWEEN ArrivalDate AND ReturnDate AND CancelDate IS NULL
				)
				ORDER BY [RoomPrice] DESC
			) AS [data]
		)

		IF(@result IS NULL)
		BEGIN
			SET @result = 'No rooms available'
		END
		RETURN @result
	END

GO

SELECT [dbo].udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)