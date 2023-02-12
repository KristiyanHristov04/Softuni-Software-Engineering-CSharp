CREATE OR ALTER PROCEDURE usp_DepositMoney(@accountId INT, @moneyAmount DECIMAL(18, 4))
AS
	BEGIN
		IF(@moneyAmount < 0)
		THROW 50001, 'Invalid Amount. Money Amount cannot be below zero!', 1
		UPDATE [Accounts]
		SET [Balance] += @moneyAmount
		WHERE [Id] = @accountId
	END