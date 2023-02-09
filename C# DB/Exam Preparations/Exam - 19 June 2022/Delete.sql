DELETE FROM [Volunteers]
WHERE [DepartmentId] =  (
							SELECT [Id] FROM [VolunteersDepartments]
							WHERE [DepartmentName] = 'Education program assistant'
						)

DELETE FROM [VolunteersDepartments]
WHERE [DepartmentName] = 'Education program assistant'
