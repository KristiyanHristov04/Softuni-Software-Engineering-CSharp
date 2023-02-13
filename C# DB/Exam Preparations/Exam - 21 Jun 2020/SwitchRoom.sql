CREATE PROC usp_SwitchRoom
(@TripId INT, @TargetRoomId INT)
AS
BEGIN
DECLARE @roomHotelId INT = 
(
    SELECT h.Id FROM Hotels AS h
    JOIN Rooms AS r ON h.Id = r.HotelId
    WHERE r.Id = @TargetRoomId
)
DECLARE @tripHotelId INT =
(
    SELECT h.Id FROM Hotels AS h
    JOIN Rooms AS r ON h.Id = r.HotelId
    JOIN Trips AS t ON r.Id = t.RoomId
    WHERE t.Id = @TripId
)
DECLARE @people INT = 
(
    SELECT COUNT(*) FROM Accounts AS a
    JOIN AccountsTrips AS at ON a.Id = at.AccountId
    JOIN Trips AS t ON at.TripId = t.Id
    WHERE t.Id = @TripId
)
IF (@roomHotelId <> @tripHotelId) THROW 50001, 'Target room is in another hotel!', 1
IF ((SELECT Beds FROM Rooms WHERE Id = @TargetRoomId) < @people) THROW 50002, 'Not enough beds in target room!', 1

UPDATE Trips
SET RoomId = @TargetRoomId
WHERE Id = @TripId
END