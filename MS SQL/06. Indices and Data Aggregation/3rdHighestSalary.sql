SELECT DISTINCT [DepartmentID], [Salary] FROM
  (
	SELECT [DepartmentID], 
	[Salary],
	DENSE_RANK() OVER(PARTITION BY [DepartmentID] ORDER BY [Salary] DESC) AS [ThirdHighestSalary]
	FROM [Employees]
  ) AS [RankedBySalary]
WHERE [ThirdHighestSalary] = 3