SELECT [Name], [PhoneNumber], LTRIM(SUBSTRING([Address], CHARINDEX(',', [Address]) + 1, LEN([Address]))) AS [Address] FROM (
					SELECT [Name], [PhoneNumber], [Address] FROM [Volunteers]
					WHERE [DepartmentId] =
											(
											SELECT [Id] FROM [VolunteersDepartments]
											WHERE [DepartmentName] = 'Education program assistant'
											)
				) AS [data]
WHERE [Address] LIKE '%Sofia%'
ORDER BY [Name]