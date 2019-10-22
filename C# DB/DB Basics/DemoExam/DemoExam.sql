CREATE DATABASE Bitbucket

CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY
,Username VARCHAR(30) NOT NULL
,Password VARCHAR(30) NOT NULL
,Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories(
Id INT PRIMARY KEY IDENTITY
,Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
,ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
CONSTRAINT PK_ReposContributors PRIMARY KEY (RepositoryId, ContributorId)
)

CREATE TABLE Issues(
Id INT PRIMARY KEY IDENTITY
,Title VARCHAR(255) NOT NULL
,IssueStatus CHAR(6) NOT NULL
,RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
,AssigneeId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits(
Id INT PRIMARY KEY IDENTITY
,Message VARCHAR(255) NOT NULL
,IssueId INT FOREIGN KEY REFERENCES Issues(Id)
,RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL
,ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files(
Id INT PRIMARY KEY IDENTITY
,Name VARCHAR(100) NOT NULL
,Size DECIMAL (18,2) NOT NULL
,ParentId INT FOREIGN KEY REFERENCES Files(Id)
,CommitId INT FOREIGN KEY REFERENCES Commits(Id)
)

--p02

INSERT INTO Issues(Title,	IssueStatus,	RepositoryId,	AssigneeId) VALUES
('Critical Problem with HomeController.cs file',	'open',	1,	4)
,('Typo fix in Judge.html',	'open',	4,	3)
,('Implement documentation for UsersService.cs', 'closed',	8,	2)
,('Unreachable code in Index.cs',	'open',	9,	8)


INSERT INTO Files(Name,	Size,	ParentId,	CommitId) VALUES
 ('Trade.idk',	2598.0,	1,	1)
,('menu.net',	9238.31,	2,	2)
,('Administrate.soshy',	1246.93,	3,	3)
,('Controller.php',	7353.15,	4,	4)
,('Find.java',	9957.86,	5,	5)
,('Controller.json',	14034.87,	3,	6)
,('Operate.xix',	7662.92,	7,	7)

--p03

UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--p04

DELETE RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId IN (
					   SELECT r.Id
	                   FROM Repositories AS r
					   WHERE r.[Name] = 'Softuni-Teamwork'
					   )

--p05

SELECT Id, Message, RepositoryId, ContributorId
FROM Commits
ORDER BY id, Message, RepositoryId, ContributorId

--p06

SELECT Id, Name, Size
FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id, Name

--p07

SELECT i.Id 
,CONCAT(u.Username, ' : ', i.Title) as IssueAssignee
FROM Issues as i
JOIN Users as u
ON u.Id = i.AssigneeId
WHERE u.Id = i.AssigneeId
ORDER BY i.Id DESC, IssueAssignee

--p08

SELECT f.Id
	,f.Name
	,CONCAT(f.Size, 'KB') as Size
FROM Files as f
LEFT JOIN Files as p
ON p.ParentId = f.Id
WHERE p.Id IS NULL 
ORDER BY f.Id, f.Name, Size DESC


--p09 

SELECT TOP (5) r.Id, r.Name, COUNT(c.ContributorId) as Commits
FROM Repositories as r
JOIN RepositoriesContributors as rc
ON rc.RepositoryId = r.Id
JOIN Commits as c
ON c.RepositoryId = r.Id
GROUP BY r.Id,r.Name
ORDER BY Commits DESC, r.Id, r.Name

--p10

SELECT u.Username, AVG(f.Size) as Size
FROM Users as u
JOIN Commits as c
ON c.ContributorId = u.Id
JOIN Files as f
ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY AVG(f.Size) DESC, u.Username

--p11

GO

CREATE FUNCTION udf_UserTotalCommits (@username VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @commitsCount INT = (
							SELECT Count(*)
							FROM Commits as c
							JOIN Users as u
							ON u.Id = c.ContributorId
							WHERE u.Username = @username
								)
	RETURN @commitsCount
END

GO

--12

CREATE PROC usp_FindByExtension(@extension VARCHAR(10))
AS
BEGIN
	SELECT Id, Name, 
	CONCAT(Size, 'KB') as Size
	FROM Files
	WHERE RIGHT(Name, LEN(@extension)) = @extension
	ORDER BY Id, Name, Size DESC
END