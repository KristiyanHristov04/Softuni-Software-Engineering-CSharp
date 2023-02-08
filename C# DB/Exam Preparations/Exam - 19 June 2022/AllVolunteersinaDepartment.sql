CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
	BEGIN
		DECLARE @count INT = 
		(
			SELECT COUNT(*) FROM [Volunteers] AS [v]
			WHERE [DepartmentId] = 
								(
									SELECT [Id] FROM [VolunteersDepartments]
									WHERE [DepartmentName] = @VolunteersDepartment
								)
		)
		RETURN @count
	END

GO 

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Education program assistant')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Guest engagement')

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events')

