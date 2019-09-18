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

