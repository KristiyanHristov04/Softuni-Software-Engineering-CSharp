INSERT INTO [Towns]([Name])
	VALUES
	('Sofia'),
	('Plovdiv'),
	('Varna'),
	('Burgas')

INSERT INTO [Departments]([Name])
	VALUES
	('Engineering'),
	('Sales'),
	('Marketing'),
	('Software Development'),
	('Quality Assurance')

INSERT INTO [Addresses]([AdressText], [TownId])
	VALUES
	('a', 1),
	('ab', 1),
	('abc', 2),
	('abcd', 3),
	('abcde', 4)

INSERT INTO [Employees]([FirstName], [MiddleName], [LastName], [DepartmentId], [AddressId])
	VALUES
	('Ivan', 'Ivanov', 'Ivanov', 1, 2),
	('Petar', 'Petrov', 'Petrov', 2, 3),
	('Maria', 'Petrova', 'Ivanova', 3, 1),
	('Ivan', 'Teziev', 'Ivanov', 4, 4),
	('Petar', 'Pan', 'Pan', 5, 5)

SELECT * FROM [Employees]
SELECT * FROM [Departments]
SELECT * FROM [Addresses]
SELECT * FROM [Towns]