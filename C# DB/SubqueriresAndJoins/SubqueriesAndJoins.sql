--Problem 1. Employee Address

SELECT TOP (5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
FROM Employees as e
JOIN Addresses as a
ON a.AddressID = e.AddressID
ORDER BY e.AddressID

--Problem 2. Addresses with Towns

SELECT TOP (50) e.FirstName, e.LastName, t.Name, a.AddressText
FROM Employees as e
JOIN Addresses as a
ON a.AddressID = e.AddressID
JOIN Towns as t
ON t.TownID = a.TownID
ORDER BY e.FirstName, e.LastName

--Problem 3. Sales Employee

SELECT e.EmployeeID, e.FirstName, e.LastName, d.Name
FROM Employees as e
JOIN Departments as d
ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

--Problem 4. Employee Departments

SELECT TOP (5) e.EmployeeID, e.FirstName, e.Salary, d.Name
FROM Employees as e
JOIN Departments as d
ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--Problem 5. Employees Without Project

SELECT TOP (3) e.EmployeeID, e.FirstName
FROM Employees as e
LEFT JOIN  EmployeesProjects as ep
ON ep.EmployeeID = e.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--Problem 6. Employees Hired After

SELECT e.FirstName, e.LastName, e.HireDate, d.Name as DeptName
FROM Employees as e
JOIN Departments as d
ON e.DepartmentID = d.DepartmentID AND e.HireDate > '01-01-1999' AND d.Name IN('Sales','Finance')
ORDER BY e.HireDate

--Problem 7. Employees with Project

SELECT TOP (5) e.EmployeeID, e.FirstName, p.Name
FROM Employees as e
JOIN EmployeesProjects as ep
ON e.EmployeeID = ep.EmployeeID
JOIN Projects as p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '08-13-2002' AND p.EndDate IS NULL
ORDER BY e.EmployeeID

--Problem 8. Employee 24

SELECT e.EmployeeID, e.FirstName,
CASE 
	WHEN YEAR(p.StartDate) >= 2005 THEN NULL
	ELSE p.Name
END as ProjectName
FROM Employees as e
JOIN EmployeesProjects as ep
ON ep.EmployeeID = e.EmployeeID
RIGHT JOIN Projects as p
ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24 

--Problem 9. Employee Manager

SELECT e.EmployeeID, e.FirstName, m.EmployeeID, m.FirstName
FROM Employees as e
JOIN Employees as m
ON m.EmployeeID =  e.ManagerID
WHERE e.ManagerID IN(3,7)
ORDER BY e.EmployeeID

--Problem 10. Employee Summary

SELECT TOP (50) e.EmployeeID,
	CONCAT(e.FirstName,' ',e.LastName) as EmployeeName,
	CONCAT(m.FirstName,' ',m.LastName) as ManagerName,
	d.Name as DepartmentName
FROM Employees as e
JOIN Employees as m
ON m.EmployeeID = e.ManagerID
JOIN Departments as d
ON d.DepartmentID = e.DepartmentID
ORDER BY e.EmployeeID

--Problem 11. Min Average Salary

SELECT MIN(mas.AverageSalary) as MinAverageSalary
FROM
(
SELECT AVG(Salary) as AverageSalary
FROM Employees
GROUP BY DepartmentID
) as mas

--Problem 12. Highest Peaks in Bulgaria

SELECT c.CountryCode, m.MountainRange, p.PeakName, p.Elevation
FROM Countries as c
JOIN MountainsCountries as mc
ON mc.CountryCode = c.CountryCode
JOIN Mountains as m
ON m.Id = mc.MountainId
JOIN Peaks as p
ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges 

SELECT c.CountryCode, 
	COUNT(m.MountainRange) as MountainRanges
FROM Countries as c
JOIN MountainsCountries as mc
ON mc.CountryCode = c.CountryCode
JOIN Mountains as m
ON m.Id = mc.MountainId
WHERE c.CountryCode IN('BG', 'RU', 'US')
GROUP BY c.CountryCode

-- 14. Countries With or Without Rivers 

