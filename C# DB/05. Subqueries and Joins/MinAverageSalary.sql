SELECT MIN([AverageSalaryForDepartment]) AS [MinAverageSalary] FROM 
	(SELECT AVG([Salary]) AS [AverageSalaryForDepartment]
	FROM [Employees]
	GROUP BY [DepartmentID]) AS [data]