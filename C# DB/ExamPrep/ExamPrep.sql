CREATE DATABASE School

USE School

--p01

CREATE TABLE Students(
Id INT PRIMARY KEY IDENTITY
,FirstName NVARCHAR(30) NOT NULL
,MiddleName NVARCHAR(25)
,LastName NVARCHAR(30) NOT NULL
,Age INT CHECK (Age BETWEEN 5 AND 100)
,Address NVARCHAR(50)
,Phone NCHAR(10)
)

CREATE TABLE Subjects(
Id INT PRIMARY KEY IDENTITY
,Name NVARCHAR(20) NOT NULL
,Lessons INT CHECK(Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects(
Id INT PRIMARY KEY IDENTITY
,StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
,SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
,Grade DECIMAL(3,2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams(
Id INT PRIMARY KEY IDENTITY
,Date DATETIME
,SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
,ExamId INT FOREIGN KEY REFERENCES Exams(Id) NOT NULL
,Grade DECIMAL(3,2) CHECK(Grade BETWEEN 2 AND 6) NOT NULL
CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentId, ExamId)
)

CREATE TABLE Teachers(
Id INT PRIMARY KEY IDENTITY
,FirstName NVARCHAR(20) NOT NULL
,LastName NVARCHAR(20) NOT NULL
,Address NVARCHAR(20) NOT NULL
,Phone CHAR(10)
,SubjectId INT FOREIGN KEY REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers(
StudentId INT FOREIGN KEY REFERENCES Students(Id) NOT NULL
,TeacherId INT FOREIGN KEY REFERENCES Teachers(Id) NOT NULL
CONSTRAINT PK_StudentsTeachers PRIMARY KEY(StudentId, TeacherId)
)

--p02

INSERT INTO Subjects(Name, Lessons) VALUES
('Geometry', 12)
,('Health', 10)
,('Drama',	7)
,('Sports',	9)

INSERT INTO Teachers(FirstName,	LastName, Address, Phone, SubjectId) VALUES
 ('Ruthanne', 'Bamb',	'84948 Mesta Junction',	'3105500146',	6)
,('Gerrard', 'Lowin',	'370 Talisman Plaza',	'3324874824',	2)
,('Merrile', 'Lambdin',	'81 Dahle Plaza',	'4373065154',	5)
,('Bert', 'Ivie', '2 Gateway Circle',	'4409584510',	4)

--p03

UPDATE StudentsSubjects
SET Grade = 6
WHERE SubjectId IN (1,2) AND Grade >= 5.50

--p04

DELETE StudentsTeachers
WHERE TeacherId IN (
					SELECT Id
					FROM Teachers
					WHERE Phone LIKE '%72%'
					)

DELETE Teachers
WHERE Phone LIKE '%72%'

--p05

SELECT FirstName, LastName, Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--p06

SELECT s.FirstName, s. LastName, COUNT(st.TeacherId) as TeachersCount
FROM Students as s
JOIN StudentsTeachers as st
ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

--p07

SELECT CONCAT(s.FirstName,' ', s.LastName) as [Full Name]
FROM Students as s
LEFT JOIN StudentsExams as se
ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

--p08

SELECT TOP(10) s.FirstName, s.LastName, CAST(AVG(se.Grade) as DECIMAL(3,2)) as Grade
FROM Students as s
LEFT JOIN StudentsExams as se
ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName

--p09

SELECT CONCAT(s.FirstName, ' ', s.MiddleName + ' ', s.LastName) as [Full Name]
FROM Students as s
LEFT JOIN StudentsSubjects as ss
ON ss.StudentId = s.Id
WHERE ss.SubjectId IS NULL
ORDER BY [Full Name]

--p10

SELECT s.Name, AVG(ss.Grade) as AverageGrade
FROM Subjects as s
JOIN StudentsSubjects as ss
ON ss.SubjectId = s.Id
GROUP BY s.Name, s.Id
ORDER BY s.Id

--p11