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

--Problem 14.	Games from 2011 and 2012 year

SELECT TOP (50) Name, FORMAT(Start,'yyyy-MM-dd') AS Start
 FROM Games
 WHERE YEAR(Start) BETWEEN 2011 AND 2012
ORDER BY Start, Name

--Problem 15.	 User Email Providers

SELECT Username, SUBSTRING(Email,CHARINDEX('@', Email) + 1,LEN(Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

--Problem 16.	 Get Users with IPAdress Like Pattern

SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

--17. Show All Games with Duration 

SELECT Name,
CASE
	WHEN DATEPART(HOUR,Start) BETWEEN 0 AND 11 THEN 'Morning' 
	WHEN DATEPART(HOUR,Start) BETWEEN 12 AND 17 THEN 'Afternoon' 
	WHEN DATEPART(HOUR,Start) BETWEEN 18 AND 23 THEN 'Evening'
END AS [Part of the day],

CASE 
	WHEN Duration <= 3 THEN 'Extra Short '
	WHEN Duration BETWEEN 4 AND 6 THEN 'Short '
	WHEN Duration > 6 THEN 'Long'
	WHEN Duration IS NULL THEN 'Extra Long'
END AS Duration

FROM Games
ORDER BY Name, Duration, [Part of the day]