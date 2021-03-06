--01. Records� Count 

SELECT COUNT(Id) AS Count 
FROM WizzardDeposits

--02. Longest Magic Wand 

SELECT TOP (1) MagicWandSize AS LongestMagicWand
FROM WizzardDeposits
ORDER BY LongestMagicWand DESC

--03. Longest Magic Wand per Deposit Groups 

SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--04. Smallest Deposit Group per Magic Wand Size

SELECT TOP (2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--05. Deposits Sum 

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--06. Deposits Sum for Ollivander Family 

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator LIKE 'Ollivander family'
GROUP BY DepositGroup

--07. Deposits Filter 

SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator LIKE 'Ollivander family' 
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--08. Deposit Charge 

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup 

--09. Age Groups

SELECT wc.AgeGroup, COUNT(wc.AgeGroup) AS WizardCount
FROM (
		SELECT 
			CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			WHEN Age > 60 THEN '[61+]'
		END AS AgeGroup
		FROM WizzardDeposits )AS wc 
GROUP BY AgeGroup


--10. First Letter 

SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName
ORDER BY FirstLetter

--11. Average Interest 

SELECT DepositGroup,IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE YEAR(DepositStartDate) >= 1985
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--Problem 12. * Rich Wizard, Poor Wizard

SELECT SUM(w.Difference) as SumDifference
FROM (
	  SELECT FirstName as [Host Wizard], DepositAmount as [Host Wizard Deposit]
	  , LEAD(FirstName) OVER (ORDER BY Id) as [Guest Wizard]
	  , LEAD(DepositAmount) OVER (ORDER BY Id) as [Guest Wizard Deposit]
	  , DepositAmount - LEAD(DepositAmount) OVER (ORDER BY Id) as Difference
	  FROM WizzardDeposits 
	  ) as w

--Problem 13.	Departments Total Salaries

SELECT DepartmentID, SUM(Salary) as TotalSalary
FROM Employees
GROUP BY DepartmentID

--14. Employees Minimum Salaries 

SELECT DepartmentID, MIN(Salary) as MinimumSalary
FROM Employees
WHERE DepartmentID IN (2,5,7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--Problem 15.	Employees Average Salaries

SELECT * INTO NewTable
FROM Employees
WHERE Salary > 30000

DELETE 
FROM NewTable
WHERE ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) as AverageSalary
FROM NewTable
GROUP BY DepartmentID

--16. Employees Maximum Salaries 

SELECT DepartmentID, MAX(Salary) as MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries 

SELECT COUNT(*) as Count
FROM Employees
WHERE ManagerID IS NULL

--Problem 18. *3rd Highest Salary

SELECT DISTINCT my.DepartmentID, my.Salary AS ThirdHighestSalary
FROM(
	SELECT DepartmentID, Salary ,
	DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS Rank
	FROM Employees
	) AS my
WHERE RANK = 3 

--19. Salary Challenge

SELECT TOP (10) FirstName, LastName, DepartmentID
FROM Employees AS e
WHERE Salary >
(
    SELECT AVG(Salary)
    FROM Employees AS em
    WHERE e.DepartmentID = em.DepartmentID
)