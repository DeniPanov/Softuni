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

CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY
,Name NVARCHAR (30) NOT NULL
)

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY (101,1)
, Name NVARCHAR (30) NOT NULL
)

CREATE TABLE StudentsExams(
StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
,ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL
CONSTRAINT PK_Composite_StudentID_ExamID PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students(Name) VALUES
('Mila')                                      
,('Toni')
,('Ron')

INSERT INTO Exams(Name) VALUES
 ('SpringMVC')                                      
,('Neo4j')
,('Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID) VALUES
 (1,	101)
,(1,	102)
,(2,	101)
,(3,	103)
,(2,	102)
,(2,	103)

--Problem 4. Self-Referencing 

CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY(101,1)
,Name NVARCHAR(30) NOT NULL
,ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers (Name, ManagerID) VALUES
 ('John',	NULL)
,('Maya',	106)
,('Silvia',	106)
,('Ted',	105)
,('Mark',	101)
,('Greta',	101)

--Problem 5. Online Store Database

CREATE TABLE Cities(
CityID INT PRIMARY KEY
,Name VARCHAR(50) NOT NULL
)

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY
,Name VARCHAR(50) NOT NULL
,Birthday DATE
,CityID INT FOREIGN KEY REFERENCES  Cities(CityID) NOT NULL
)

CREATE TABLE Orders(
OrderID INT PRIMARY KEY
,CustomerID INT FOREIGN KEY REFERENCES Customers(CustomerID) NOT NULL
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY
,Name VARCHAR(50) NOT NULL
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY
,Name VARCHAR(50) NOT NULL
,ItemTypeID INT FOREIGN KEY REFERENCES ItemTypes(ItemTypeID) NOT NULL
)

CREATE TABLE OrderItems(
OrderID INT FOREIGN KEY REFERENCES Orders(OrderID) NOT NULL
,ItemID INT FOREIGN KEY REFERENCES Items(ItemID) NOT NULL
CONSTRAINT PK_Composite_OrderID_ItemID PRIMARY KEY (OrderID, ItemID)
)

--Problem 6. University Database

CREATE TABLE Majors(
MajorID INT PRIMARY KEY IDENTITY
,Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Students(
 StudentID INT PRIMARY KEY IDENTITY
,StudentNumber NVARCHAR(15)
,StudentName NVARCHAR(50)
,MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments(
 PaymentID INT PRIMARY KEY IDENTITY
,PaymentDate DATE NOT NULL
,PaymentAmount DECIMAL (10,2) NOT NULL
,StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY IDENTITY
,SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Agenda(
 StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
,SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)
CONSTRAINT PK_Composite_StudentID_SubjectID PRIMARY KEY (StudentID, SubjectID)
)

--09. *Peaks in Rila 