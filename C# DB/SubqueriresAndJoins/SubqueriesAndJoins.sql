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


