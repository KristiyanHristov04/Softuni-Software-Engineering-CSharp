CREATE TABLE [Users](
	[Id] BIGINT PRIMARY KEY IDENTITY(1, 1),
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX) CHECK(DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] NVARCHAR(MAX),
	[IsDeleted] BIT
)

INSERT INTO [Users]([Username], [Password])
	VALUES
	('Vankata', '1234'),
	('Mishkata', '12345'),
	('Blagoikata', '123'),
	('Stanoikata', '555'),
	('PenkaP', '777')

SELECT * FROM [Users]