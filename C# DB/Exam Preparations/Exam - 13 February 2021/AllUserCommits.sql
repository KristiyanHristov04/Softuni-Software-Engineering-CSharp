CREATE FUNCTION udf_AllUserCommits (@username VARCHAR(30))
RETURNS INT
AS
	BEGIN
		DECLARE @commitsCount INT =
		(
			SELECT COUNT([c].ContributorId) FROM [Users] AS [u]
			LEFT JOIN [Commits] AS [c] ON [c].ContributorId = [u].Id
			GROUP BY [c].ContributorId, [u].Username
			HAVING [u].Username = @username
		)
		IF @commitsCount IS NULL
		BEGIN
			SET @commitsCount = 0
		END
		RETURN @commitsCount
	END

--Not for judge
SELECT [dbo].udf_AllUserCommits('Blalmmagilana')