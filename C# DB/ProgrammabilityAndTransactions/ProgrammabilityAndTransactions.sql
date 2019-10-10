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

CREATE PROC usp_GetTownsStartingWith (@startingSymbols NVARCHAR(50))
AS
	SELECT t.Name
	FROM Towns as t
	WHERE LEFT(t.Name, LEN(@startingSymbols)) = @startingSymbols

GO 

EXEC usp_GetTownsStartingWith b

GO

--Problem 4. Employees from Town

CREATE PROC usp_GetEmployeesFromTown (@townName NVARCHAR(30))
AS
	SELECT e.FirstName, e.LastName
	FROM Employees as e
	JOIN Addresses as a
	ON a.AddressID = e.AddressID
	JOIN Towns as t 
	ON t.TownID = a.TownID
	WHERE t.Name = @townName

GO

EXEC usp_GetEmployeesFromTown Sofia

GO

--Problem 5. Salary Level Function

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @result NVARCHAR(20)

	IF(@salary < 30000)
	BEGIN
		SET @result = 'Low'
	END

	ELSE IF(@salary <= 50000)
	BEGIN
		SET @result = 'Average'
	END

	ELSE
	SET @result = 'High'

	RETURN @result
END

GO

SELECT Salary, dbo.ufn_GetSalaryLevel(Salary) as SalaryLevel
FROM Employees

GO

--Problem 6. Employees by Salary Level 

CREATE PROC usp_EmployeesBySalaryLevel (@salaryLevel NVARCHAR(20))
AS
BEGIN
	SELECT e.FirstName, e.LastName
	FROM Employees as e
	WHERE dbo.ufn_GetSalaryLevel(e.Salary) = @salaryLevel
END

GO

EXEC usp_EmployeesBySalaryLevel 'High'

--Problem 7. Define Function