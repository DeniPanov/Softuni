--Problem 1. One-To-One Relationship

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

--Problem 2. One-To-Many Relationship

CREATE TABLE Manufacturers(
ManufacturerID INT PRIMARY KEY IDENTITY
,Name NVARCHAR (30) NOT NULL
,EstablishedOn DATE NOT NULL
)

CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(101,1)
,Name NVARCHAR (30) NOT NULL
,ManufacturerID INT NOT NULL
CONSTRAINT FK_Models_Manufacturers
FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers(Name, EstablishedOn) VALUES
 ('BMW', '07/03/1916')
,('Tesla', '01/01/2003')
,('Lada', '01/05/1966')

INSERT INTO Models(Name, ManufacturerID) VALUES
('X1',	1)
,('i6',	1)
,('Model S', 2)
,('Model X', 2)
,('Model 3', 2)
,('Nova', 3)
		
--Problem 3. Many-To-Many Relationship