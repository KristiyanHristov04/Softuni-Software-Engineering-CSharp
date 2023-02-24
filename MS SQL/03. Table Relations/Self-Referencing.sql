CREATE TABLE [Teachers](
	[TeacherID] INT PRIMARY KEY IDENTITY(101, 1),
	[Name] VARCHAR(50) NOT NULL,
	[ManagerID] INT FOREIGN KEY REFERENCES [Teachers]([TeacherID])
)

INSERT INTO [Teachers]([Name], [ManagerID])
VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

--SELECT * FROM [Teachers]