CREATE TABLE [People](
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX) CHECK (DATALENGTH([Picture]) <= 2000000),
	[Height] DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) CHECK([Gender] = 'm' OR [Gender] = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO [People]([Name], [Gender], [Birthdate])
	VALUES
	('Ivan', 'm', '1990-01-21'),
	('Misho', 'm', '1991-04-02'),
	('Blagoi', 'm', '1992-02-12'),
	('Stanoi', 'm', '1993-08-15'),
	('Penka', 'f', '1994-07-17')

SELECT * FROM [People]