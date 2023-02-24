DECLARE @userGameId INT = 
(
  SELECT ug.[Id]
  FROM [UsersGames] AS [ug] 
  JOIN [Users] AS [u] ON ug.[UserId] = u.[Id]
  JOIN [Games] AS [g] ON ug.[GameId] = g.[Id]
  WHERE u.[Username] = 'Stamat' AND g.[Name] = 'Safflower'
)
DECLARE @itemsCost DECIMAL(18, 4)


DECLARE @minLevel INT = 11
DECLARE @maxLevel INT = 12
DECLARE @playerCash DECIMAL(18, 4) = 
(
	SELECT [Cash]
    FROM [UsersGames]
    WHERE [Id] = @userGameId
)

SET @itemsCost = 
(
	SELECT SUM(Price)
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
)

IF (@playerCash >= @itemsCost)
BEGIN
	BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @itemsCost
    WHERE [Id] = @userGameId
      
    INSERT INTO [UserGameItems] (ItemId, UserGameId)
    (
		SELECT
			[Id],
			@userGameId
		FROM [Items]
		WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
	)
	COMMIT     
END

SET @minLevel = 19
SET @maxLevel = 21
SET @playerCash = 
(
	SELECT [Cash]
    FROM [UsersGames]
    WHERE [Id] = @userGameId
)

SET @itemsCost = 
(
	SELECT SUM(Price)
    FROM [Items]
    WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
)

IF (@playerCash >= @itemsCost)
BEGIN
	BEGIN TRANSACTION
    UPDATE [UsersGames]
    SET [Cash] -= @itemsCost
    WHERE [Id] = @userGameId
      
    INSERT INTO [UserGameItems] (ItemId, UserGameId)
    (
		SELECT
			[Id],
			@userGameId
		FROM [Items]
		WHERE [MinLevel] BETWEEN @minLevel AND @maxLevel
	)
	COMMIT     
END

SELECT i.[Name] AS [Item Name]
FROM [UserGameItems] AS [ugi]
JOIN [Items] AS [i] ON i.[Id] = ugi.[ItemId]
JOIN [UsersGames] AS [ug] ON ug.[Id] = ugi.[UserGameId]
JOIN [Games] AS [g] ON g.[Id] = ug.[GameId]
WHERE g.[Name] = 'Safflower'
ORDER BY [Item Name]