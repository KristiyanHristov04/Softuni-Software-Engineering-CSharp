CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(100))
AS
	BEGIN
		SELECT [Id], [Name], CONCAT([Size], 'KB') AS [Size]
		FROM [Files]
		WHERE [Name] LIKE '%' + @fileExtension
	END

GO

--Not for judge
EXECUTE [dbo].usp_SearchForFiles 'txt'