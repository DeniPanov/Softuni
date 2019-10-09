--Problem 1. Employees with Salary Above 35000

CREATE PROC usp_GetEmployeesSalaryAbove35000 
AS
	SELECT e.FirstName, e.LastName
	FROM Employees as e
	WHERE e.Salary > 35000

GO
--Problem 2. Employees with Salary Above Number

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@salary DECIMAL(18,4))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees as e
	WHERE e.Salary >= @salary

GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100

GO

--Problem 3. Town Names Starting With

