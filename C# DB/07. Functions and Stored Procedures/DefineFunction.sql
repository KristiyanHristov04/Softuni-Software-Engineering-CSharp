CREATE OR ALTER FUNCTION [ufn_IsWordComprised](@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
    DECLARE @isWordCompromised BIT = 0
    DECLARE @i INT = 1
 
    WHILE @i <= LEN(@word)
    BEGIN
        DECLARE @currentWordLetter CHAR(1) = SUBSTRING(@word, @i, 1)
        DECLARE @j INT = 1
 
        WHILE @j <= LEN(@setOfLetters)
        BEGIN
            DECLARE @currentSetLetter CHAR(1) = SUBSTRING(@setOfLetters, @j, 1)
 
            IF @currentWordLetter = @currentSetLetter
            BEGIN
                SET @isWordCompromised = 1
                BREAK
            END
 
            SET @j += 1
        END
 
        IF @isWordCompromised = 0
        BEGIN
            RETURN 0
        END
 
        SET @isWordCompromised = 0
        SET @i += 1
    END
 
    RETURN 1
END
  
SELECT [dbo].[ufn_IsWordComprised]('oistmiahf', 'Sofia')
 