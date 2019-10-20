CREATE DATABASE Service

USE Service

--p01

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY
,Username VARCHAR(30) UNIQUE NOT NULL
,Password VARCHAR(50) NOT NULL
,Name VARCHAR(50)
,Birthdate DATETIME 
,Age INT CHECK(Age BETWEEN 14 AND 110)
,Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments(
Id INT PRIMARY KEY IDENTITY
,Name VARCHAR(50) NOT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY
,FirstName VARCHAR(25)
,LastName VARCHAR(25)
,Birthdate DATETIME
,Age INT CHECK(Age BETWEEN 18 AND 110)
,DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY
,Name VARCHAR(50) NOT NULL
,DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status(
Id INT PRIMARY KEY IDENTITY
,Label VARCHAR(30) NOT NULL
)

CREATE TABLE Reports(
Id INT PRIMARY KEY IDENTITY
,CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL
,StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL
,OpenDate DATETIME NOT NULL
,CloseDate DATETIME 
,Description VARCHAR(200) NOT NULL
,UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
,EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--p02

INSERT INTO Employees(FirstName,	LastName,	Birthdate,	DepartmentId) VALUES
 ('Marlo',	'OMalley',	1958-9-21, 1)
,('Niki',	'Stanaghan', 1969-11-26, 4)
,('Ayrton',	'Senna',	1960-03-21,	9)
,('Ronnie',	'Peterson',	1944-02-14,	9)
,('Giovanna', 'Amati', 1959-07-20, 5)

INSERT INTO Reports(CategoryId,	StatusId,	OpenDate,	CloseDate,	Description	,UserId,	EmployeeId) VALUES
 (1,	1,	2017-04-13,	NULL,	'Stuck Road on Str.133',	6,	2)
,(6,	3,	2015-09-05,	2015-12-06,	'Charity trail running',	3,	5)
,(14,	2,	2015-09-07,	NULL,	'Falling bricks on Str.58',	5,	2)
,(4,	3,	2017-07-03,	2017-07-06,	'Cut off streetlight on Str.11',	1,	1)

--p03

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--p04

DELETE FROM Reports
WHERE StatusId = 4

--p05

SELECT Description, CONVERT(VARCHAR(10), OpenDate, 105) as OpenDate
FROM Reports as r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, Description

--p06

SELECT r.Description, c.Name
FROM Reports as r
JOIN Categories as c
ON c.Id = r.CategoryId
ORDER BY r.Description, c.Name

--p07

SELECT TOP(5) c.Name as CategoryName, COUNT(r.Id) as ReportsNumber
FROM Categories as c
JOIN Reports as r
ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, CategoryName

--p08

SELECT u.Username, c.Name as CategoryName
FROM Users as u
JOIN Reports as r
ON r.UserId = u.Id
JOIN Categories as c
ON c.Id = r.CategoryId
WHERE MONTH(u.Birthdate) = MONTH(r.OpenDate) AND DAY(u.Birthdate) = DAY(r.OpenDate)
ORDER BY Username, CategoryName

--p09

SELECT CONCAT(e.FirstName, ' ', e.LastName) as FullName, COUNT(u.Id) as UsersCount
FROM Employees as e
LEFT JOIN Reports as r
ON r.EmployeeId = e.Id
LEFT JOIN Users as u
ON u.Id = r.UserId
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC, FullName

--p10

SELECT 
	   CASE
	   WHEN e.FirstName IS NULL THEN 'None'
	   ELSE CONCAT(e.FirstName, ' ', e.LastName)
	   END AS Employee,

	   CASE
	   WHEN d.Name IS NULL THEN 'None'
	   ELSE d.Name
	   END AS Department
	     
	   ,c.Name as Category
	   ,r.Description
	   ,CONVERT(VARCHAR(10), r.OpenDate, 104) as OpenDate
	   ,s.Label as Status
	   ,u.Name as [User]
FROM Reports as r
FULL JOIN Employees as e
ON e.id = r.EmployeeId
FULL JOIN Departments as d
ON d.Id = e.DepartmentId
FULL JOIN Categories as c
ON c.id = r.CategoryId
FULL JOIN Status as s
ON s.Id = r.StatusId
JOIN Users as u
ON r.UserId = u.Id
ORDER BY e.FirstName DESC, e.LastName DESC, Department, Category, Description, OpenDate, Status, User

--p11

GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
RETURNS INT
BEGIN
	DECLARE @timeDiffInHours INT = DATEDIFF(HOUR, @StartDate, @EndDate )

	IF(@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0
	END

	RETURN @timeDiffInHours
END

GO

--p12 NOT FINISHED!

CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT) 
AS

	DECLARE @validInput INT = (SELECT e.Id
							   FROM Employees as e
							   JOIN Reports as r
							   ON r.EmployeeId = e.Id
							   JOIN Categories as c
							   ON r.CategoryId = c.Id
							   WHERE @EmployeeId = e.Id AND @ReportId = r.Id AND
							   e.DepartmentId = c.DepartmentId)

	DECLARE @errorMsg NVARCHAR(200) = CONCAT('Employee doesn', CHAR(39), 't belong to the appropriate department!')

	IF(@validInput IS NULL)
	BEGIN
		RAISERROR(@errorMsg, 16, 1)
	END

GO 

EXEC usp_AssignEmployeeToReport 17, 2