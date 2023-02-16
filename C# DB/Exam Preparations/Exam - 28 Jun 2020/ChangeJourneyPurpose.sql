CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
	BEGIN
		IF(@JourneyId NOT BETWEEN 1 AND 15)
			THROW 50001, 'The journey does not exist!', 1

		DECLARE @JourneyIdIfPurposeIsTheSame INT = 
		(
			SELECT [Id] FROM [Journeys]
			WHERE [Id] = @JourneyId AND 
			[Purpose] = @NewPurpose
		)

		IF(@JourneyId = @JourneyIdIfPurposeIsTheSame)
			THROW 50002, 'You cannot change the purpose!', 1

		UPDATE [Journeys]
		SET [Purpose] = @NewPurpose
		WHERE [Id] = @JourneyId

	END

GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'