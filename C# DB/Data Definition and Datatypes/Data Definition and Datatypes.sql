--Problem 1.	Create Database

CREATE DATABASE Minions

--Problem 2.	Create Tables

CREATE TABLE Minions(
ID INT NOT NULL
,Name NVARCHAR(20) NOT NULL
,Age INT NOT NULL
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Minions PRIMARY KEY (ID)

CREATE TABLE Towns(
ID INT NOT NULL
,Name NVARCHAR(30) NOT NULL
,CONSTRAINT PK_Town PRIMARY KEY (ID)
)

--Problem 3.	Alter Minions Table

ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_Towns FOREIGN KEY (TownId) REFERENCES Towns(Id) 

--Problem 4.	Insert Records in Both Tables

INSERT INTO Towns(Id, Name)
VALUES (1, 'Sofia'),
	   (2, 'Plovdiv'),
	   (3, 'Varna')

INSERT INTO Minions(Id, Name, Age, TownId)
VALUES (1, 'Kevin', 22, 1),
	   (2, 'Bob', 15, 3),
	   (3, 'Steward', NULL, 2)

--Problem 5.	Truncate Table Minions

TRUNCATE TABLE Minions

--Problem 6.	Drop All Tables

DROP DATABASE Minions

--Problem 7.	Create Table People

CREATE TABLE People(
Id INT PRIMARY KEY IDENTITY
,Name NVARCHAR (200) NOT NULL
,Picture VARBINARY (2048) 
,Height DECIMAL (5 ,2)
,Weight DECIMAL (5 ,2)
,GENDER CHAR (1) NOT NULL CHECK (GENDER = 'm' OR GENDER = 'f')
,Birthdate DATE NOT NULL
,Biography NVARCHAR(MAX) 
)

INSERT INTO People(Name, Picture, Height, Weight, GENDER, Birthdate, Biography)VALUES
('Deni', 200, 182, 94.8, 'm', '1990-05-15','Some random text...')
,('Sanya', 500, 163, 53, 'f', '1991-05-19','Some random text...')
,('Venci', 248, 178, 97, 'm', '1990-02-08','Some random text...')
,('Gosho', 512, 185, 97, 'm', '1993-02-01','Some random text...')
,('Pesho', 1024, 175, 80, 'm','1997-11-12','Some random text...');

--Problem 8.	Create Table Users

CREATE TABLE Users(
ID INT PRIMARY KEY IDENTITY
,Username VARCHAR (30) NOT NULL
,Password VARCHAR (26) NOT NULL
,ProfilePicture VARBINARY (MAX)
,LastLoginTime DATE
,IsDeleted BIT
)

INSERT INTO Users (Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
('Albena', 'TopSecret', 1000, '2019-01-01',0)
,('Angel', 'TopSecret', 254, '2019-02-01',1)
,('Sasho', 'TopSecret', 512, '2019-03-01',0)
,('Mario', 'TopSecret', 1000, '2019-04-01',1)
,('Krasi', 'TopSecret', 1000, '2019-05-01',0);

--Problem 9.	Change Primary Key

ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC275228AF24]

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (ID, Username)

--Problem 10.	Add Check Constraint

ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK (LEN(Password) >= 5) 

--Problem 11.	Set Default Value of a Field

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--Problem 12.	Set Unique Field

ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (ID)

ALTER TABLE Users
ADD CONSTRAINT UQ_Username UNIQUE (Username) 

ALTER TABLE Users
ADD CONSTRAINT CHK_UsernameLenght CHECK (LEN(Username) >= 3) 

--Problem 13.	Movies Database

CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY
,DirectorName NVARCHAR (30) NOT NULL
,Notes NVARCHAR(MAX)
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY
,GenreName NVARCHAR (30) NOT NULL
,Notes NVARCHAR(MAX)
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY
,CategoryName NVARCHAR (30) NOT NULL
,Notes NVARCHAR(MAX)
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY
,Title NVARCHAR (50)
,DirectorId INT NOT NULL
,CopyrightYear DATE
,Lenght DECIMAL (5,2)
,GenreId INT NOT NULL
,CategoryId INT NOT NULL
,Rating DECIMAL (5,2)
,Notes NVARCHAR (MAX)

CONSTRAINT FK_Director FOREIGN KEY (DirectorId) REFERENCES Directors(Id)
,CONSTRAINT FK_Genre FOREIGN KEY (GenreId) REFERENCES Genres(Id)
,CONSTRAINT FK_Category FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Peter', 'Some notes here...')
,('Ivan', 'Some notes here...')
,('Dani', 'Some notes here...')
,('Martin', NULL)
,('Ralica', 'Some notes here...')

INSERT INTO Categories(CategoryName, Notes) VALUES
('Action', 'Some additional notes...')
,('Comedy', 'Some additional notes...')
,('Horror', 'Some additional notes...')
,('Musical', 'Some additional notes...')
,('Drama', 'Some additional notes...')

INSERT INTO Genres(GenreName, Notes) VALUES
('Action', 'Some additional notes...')
,('Comedy', 'Some additional notes...')
,('Horror', 'Some additional notes...')
,('Musical', 'Some additional notes...')
,('Drama', 'Some additional notes...')

INSERT INTO Movies(Title, DirectorId,CopyrightYear, Lenght, GenreId, CategoryId,Rating, Notes) VALUES -- Add Ids and insert them in the table
('Misson Impossible', 1,'1999', 90, 1, 1, 7.5, 'Some notes about the movie ...')
,('Terminator', 2, '1997', 87, 1,1, 8, 'Some notes about the movie ...')
,('Lord of the rings', 3,'1999', 120, 4, 5, 8.2, 'Some notes about the movie ...')
,('Troy', 4,'2000', 90, 5, 2, 6, 'Some notes about the movie ...')
,('Game of thrones', 5,'2012', 60, 5,5, 10, 'Some notes about the movie ...')

--Problem 14.	Car Rental Database

CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY
,CategoryName NVARCHAR (25) NOT NULL
,DailyRate DECIMAL(7,2) NOT NULL
,WeeklyRate DECIMAL(8,2) NOT NULL
,MonthlyRate DECIMAL(9,2) NOT NULL
,WeekendRate DECIMAL(7,2) NOT NULL
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY
,PlateNumber NVARCHAR(15) NOT NULL
,Manufacturer NVARCHAR(25) NOT NULL
,Model NVARCHAR(25) NOT NULL
,CarYear DATE NOT NULL
,CategoryId INT NOT NULL 
,Doors INT NOT NULL
,Picture VARBINARY (MAX)
,Condition NVARCHAR (20) 
,Available VARCHAR (10) NOT NULL

CONSTRAINT FK_Cars_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY
,FirstName NVARCHAR (20) NOT NULL
,LastName NVARCHAR (25) NOT NULL
,Title NVARCHAR (20) NOT NULL
,Notes NVARCHAR (MAX)
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY
,DriverLicenceNumber NVARCHAR(20) NOT NULL
,FullName NVARCHAR(50) NOT NULL
,Address NVARCHAR(100) NOT NULL
,City NVARCHAR(25) NOT NULL
,ZIPCode INT NOT NULL
,Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY
,EmployeeId INT NOT NULL
,CustomerId INT NOT NULL
,CarId INT NOT NULL
,TankLevel DECIMAL (5,2) NOT NULL
,KilometrageStart INT NOT NULL
,KilometrageEnd INT NOT NULL
,TotalKilometrage INT NOT NULL
,StartDate DATE NOT NULL
,EndDate DATE NOT NULL
,TotalDays INT NOT NULL
,RateApplied DECIMAL (5,2)
,TaxRate DECIMAL (8,2) NOT NULL
,OrderStatus NVARCHAR(20) NOT NULL
,Notes NVARCHAR(MAX)

CONSTRAINT FK_RentalOrders_Employees FOREIGN KEY (EmployeeId) REFERENCES Employees(Id)
,CONSTRAINT FK_RentalOrders_Customers FOREIGN KEY (CustomerId) REFERENCES Customers(Id)
,CONSTRAINT FK_RentalOrders_Cars FOREIGN KEY (CarId) REFERENCES Cars(Id)
)

INSERT INTO Categories( CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('LIGHT AVOMOBILE', 121.52, 235.25, 526.35, 150.00 ),
('COMMERCIAL CAR', 121.62, 235.45, 526.75, 151.00 ),
('CARAVAN', 121.62, 235.45, 526.75, 151.00 )

INSERT INTO Cars ( PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)VALUES
('DR2568DE', 'RENO', 'MEGAN' , '2000', 1,4, NULL, NULL, 'YES' ),
('DR7568DE', 'AUDI', 'X7' , '2000', 1, 4, NULL, NULL, 'YES' ),
('RR2568DE', 'BMV', 'D5' , '2001', 1, 4, NULL, NULL, 'YES' )

INSERT INTO	Employees (FirstName, LastName, Title, Notes)VALUES
('Venci','VERCHOV','BDAHDAB', NULL),
('Deni','PANOV',   'BDAHDAJB', NULL),
('Sanya', 'PANOVA', 'BDAHDAJB', NULL)

INSERT INTO	Customers ( DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)VALUES
('DRS2569SA', 'VENCISLAV VERCHOV', 'BULGARIA', 'SOFIA', 1000, NULL ),
('DRS2669SA', 'VENCISLAV VERCHOV', 'BULGARIA', 'SOFIA', 1000, NULL ),
('DRS2579SA', 'VENCISLAV VERCHOV', 'BULGARIA', 'SOFIA', 1000, NULL )


INSERT INTO RentalOrders ( EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd,
 TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)VALUES
 (1, 2, 4, 60, 0, 200000, 20000, '2000-01-01', '2010-01-01', 3650, 100, 50, 'GOOD', NULL),
 (2, 2, 5, 60, 120000, 200000, 20000, '2001-01-01', '2011-01-01', 3650, 100, 50, 'GOOD', NULL), 
 (3, 2, 6, 60, 0, 200000, 20000, '2002-01-01', '2012-01-01', 3650, 100, 50, 'GOOD', NULL) 

 --15. Hotel Database



