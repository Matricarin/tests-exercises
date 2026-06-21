
WITH RankedEmmployees AS (
	SELECT Id,
		DepartmentId,
		Salary,
		pg_catalog.dense_rank() OVER (
			PARTITION BY DepartmentId
			ORDER BY Salary DESC) AS salary_rank
	FROM Employees)
SELECT Id,
	DepartmentId,
	Salary
	FROM RankedEmmployees
	WHERE salary_rank <= 3;
