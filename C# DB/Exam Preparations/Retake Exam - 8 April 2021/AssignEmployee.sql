CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	BEGIN
		DECLARE @employeeDepartmentId INT =
		(
			SELECT [DepartmentId] FROM [Employees]
			WHERE [Id] = @EmployeeId
		)

		DECLARE @reportDepartmentId INT =
		(
			SELECT [c].[DepartmentId] FROM [Reports] AS [r]
			JOIN [Categories] AS [c] ON [c].Id = [r].CategoryId
			WHERE [r].[Id] = @ReportId
		)

		IF @reportDepartmentId <> @employeeDepartmentId
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
		UPDATE [Reports]
		SET [EmployeeId] = @EmployeeId
		WHERE [Id] = @ReportId
	END

GO

EXEC usp_AssignEmployeeToReport 17, 2

EXEC usp_AssignEmployeeToReport 30, 1