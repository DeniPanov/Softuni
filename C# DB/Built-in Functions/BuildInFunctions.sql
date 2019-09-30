--Problem 1. Find Names of All Employees by First Name

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--Problem 2. Find Names of All employees by Last Name 

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employess 

SELECT FirstName
FROM Employees
WHERE DepartmentID IN(3,10) AND HireDate BETWEEN '1995-01-01' AND '2005-12-31'

--04. Find All Employees Except Engineers 

SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--Problem 5.	Find Towns with Name Length

SELECT Name
FROM Towns
WHERE LEN(Name) = 5 OR LEN(Name) = 6
ORDER BY Name

--06. Find Towns Starting With 

SELECT *
FROM Towns
WHERE LEFT(Name, 1) LIKE '[mkbe]%'
ORDER BY Name

--07. Find Towns Not Starting With

SELECT *
FROM Towns
WHERE LEFT(Name, 1) NOT LIKE '[rbd]%'
ORDER BY Name

--08. Create View Employees Hired After 

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE HireDate >= '2001-01-01'

--09. Length of Last Name 

SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10. Rank Employees by Salary 

SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER   
    (PARTITION BY Salary ORDER BY EmployeeID) AS Rank  
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

--Problem 11. Find All Employees with Rank 2 NOT COMPLETED

SELECT EmployeeID, FirstName, LastName, Salary,
	DENSE_RANK() OVER   
    (PARTITION BY Salary ORDER BY EmployeeID) AS Rank
FROM Employees e
WHERE e.Salary BETWEEN 10000 AND 50000 AND e.Rank = 2
ORDER BY e.Salary DESC

--Problem 12.	Countries Holding ‘A’ 3 or More Times

SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--Problem 13. Mix of Peak and River Names

SELECT PeakName, RiverName, 
LOWER(PeakName + SUBSTRING(RiverName, 2, LEN(RiverName))) as Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix