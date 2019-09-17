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

