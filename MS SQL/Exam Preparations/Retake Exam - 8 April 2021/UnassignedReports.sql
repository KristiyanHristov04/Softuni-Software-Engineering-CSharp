SELECT [Description], FORMAT([OpenDate], 'dd-MM-yyyy') FROM [Reports]
WHERE [EmployeeId] IS NULL
ORDER BY [OpenDate] ASC, [Description] ASC