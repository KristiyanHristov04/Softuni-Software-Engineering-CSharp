CREATE PROCEDURE usp_AnnualRewardLottery (@TouristName VARCHAR(50))
AS
	BEGIN
		DECLARE @countOfVisitedSites INT =
		(
				SELECT COUNT(*) FROM [Tourists] AS [t]
				JOIN [SitesTourists] AS [st] ON [st].TouristId = [t].Id
				JOIN [Sites] AS [s] ON [s].Id = [st].SiteId
				GROUP BY [t].[Name]
				HAVING [t].[Name] = @TouristName
		)

		IF(@countOfVisitedSites < 25)
		BEGIN
			UPDATE [Tourists]
			SET [Reward] = NULL
		END
		IF(@countOfVisitedSites >= 25)
		BEGIN
			UPDATE [Tourists]
			SET [Reward] = 'Bronze badge'
		END
		IF(@countOfVisitedSites >= 50)
		BEGIN
			UPDATE [Tourists]
			SET [Reward] = 'Silver badge'
		END
		IF(@countOfVisitedSites >= 100)
		BEGIN
			UPDATE [Tourists]
			SET [Reward] = 'Gold badge'
		END

		SELECT [Name], [Reward] FROM [Tourists]
		WHERE [Name] = @TouristName
	END

GO

EXEC usp_AnnualRewardLottery 'Gerhild Lutgard'

EXEC usp_AnnualRewardLottery 'Teodor Petrov'

EXEC usp_AnnualRewardLottery 'Zac Walsh'

EXEC usp_AnnualRewardLottery 'Brus Brown'
