--Problem 1.	One-To-One Relationship

CREATE TABLE Passports(
PassportID INT PRIMARY KEY IDENTITY(101,1)
,PassportNumber NVARCHAR(8)
)

CREATE TABLE Persons(
PersonID INT PRIMARY KEY IDENTITY
,FirstName NVARCHAR (30) NOT NULL
,Salary INT 
,PassportID INT NOT NULL UNIQUE
CONSTRAINT FK_Persons_Passports
FOREIGN KEY (PassportID)
REFERENCES Passports (PassportID)
)

INSERT INTO Passports(PassportNumber) VALUES
('N34FG21B')
,('K65LO4R7')
,('ZE657QP2')

INSERT INTO Persons(FirstName, Salary,PassportID) VALUES
 ('Roberto', 43300.00, 102)
,('Tom', 56100.00, 103)
,('Yana', 60200.00,	101)

--Problem 2.	One-To-Many Relationship

