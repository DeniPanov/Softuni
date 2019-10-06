--Problem 1. Employee Address

SELECT TOP (5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
FROM Employees as e
JOIN Addresses as a
ON a.AddressID = e.AddressID
ORDER BY e.AddressID

--Problem 2. Addresses with Towns