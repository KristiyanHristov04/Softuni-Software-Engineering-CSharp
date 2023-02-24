DECLARE @userId INT =
(
    SELECT Id
    FROM Users
    WHERE Username = 'Alex'
);

DECLARE @gameId INT =
(
    SELECT Id
    FROM Games
    WHERE [Name] = 'Edinburgh'
);

-- Transaction for Blackguard

BEGIN TRANSACTION;

DECLARE @itemId INT =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Blackguard'
);

-- Get money

UPDATE UsersGames
  SET
      Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
      AND GameId = @gameId;

-- Check if Cach is still positive

IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
    BEGIN
        PRINT 'Cash is not enough!';
        ROLLBACK;
END;

-- Assign item

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
);

COMMIT;

-- End of transaction

-- Transaction for Bottomless Potion of Amplification

BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Bottomless Potion of Amplification'
);

-- Get money

UPDATE UsersGames
  SET
      Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
      AND GameId = @gameId;

-- Check if Cach is still positive

IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
    BEGIN
        PRINT 'Cash is not enough!';
        ROLLBACK;
END;

-- Assign item

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
);

COMMIT;

-- End of transaction

-- Transaction for Eye of Etlich (Diablo III)

BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Eye of Etlich (Diablo III)'
);

-- Get money

UPDATE UsersGames
  SET
      Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
      AND GameId = @gameId;

-- Check if Cach is still positive

IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
    BEGIN
        PRINT 'Cash is not enough!';
        ROLLBACK;
END;

-- Assign item

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
);

COMMIT;

-- End of transaction

-- Transaction for Gem of Efficacious Toxin

BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Gem of Efficacious Toxin'
);

-- Get money

UPDATE UsersGames
  SET
      Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
      AND GameId = @gameId;

-- Check if Cach is still positive

IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
    BEGIN
        PRINT 'Cash is not enough!';
        ROLLBACK;
END;

-- Assign item

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
);

COMMIT;

-- End of transaction

-- Transaction for Golden Gorget of Leoric 

BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Golden Gorget of Leoric'
);

-- Get money

UPDATE UsersGames
  SET
      Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
      AND GameId = @gameId;

-- Check if Cach is still positive

IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
    BEGIN
        PRINT 'Cash is not enough!';
        ROLLBACK;
END;

-- Assign item

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
);

COMMIT;

-- End of transaction

-- Transaction for Hellfire Amulet 

BEGIN TRANSACTION;

SET @itemId =
(
    SELECT Id
    FROM Items
    WHERE [Name] = 'Hellfire Amulet'
);

-- Get money

UPDATE UsersGames
  SET
      Cash -= 
(
    SELECT Price
    FROM Items
    WHERE Id = @itemId
)
WHERE UserId = @userId
      AND GameId = @gameId;

-- Check if Cach is still positive

IF(0 >
  (
      SELECT Cash
      FROM UsersGames
      WHERE UserId = @userId
            AND GameId = @gameId
  ))
    BEGIN
        PRINT 'Cash is not enough!';
        ROLLBACK;
END;

-- Assign item

INSERT INTO UserGameItems
VALUES
(
       @itemId,
(
    SELECT Id
    FROM UsersGames
    WHERE UserId = @userId
          AND GameId = @gameId
)
);

COMMIT;

-- End of transaction

-- Final Selection

SELECT u.Username,
       g.[Name],
       ug.Cash,
       i.[Name] AS [Item Name]
FROM Users AS u
     JOIN UsersGames AS ug ON ug.UserId = u.Id
     JOIN Games AS g ON g.Id = ug.GameId
     JOIN UserGameItems AS ugi ON ugi.UserGameId = ug.Id
     JOIN Items AS i ON i.Id = ugi.ItemId
WHERE g.Id = @gameId
ORDER BY [Item Name];