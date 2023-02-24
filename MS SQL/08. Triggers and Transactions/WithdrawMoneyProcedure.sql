CREATE OR ALTER PROCEDURE usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(16, 4))
AS
	BEGIN
		IF(@moneyAmount < 0)
		THROW 50001, 'Invalid Amount. Money Amount cannot be below zero!', 1
		UPDATE [Accounts]
		SET [Balance] -= @moneyAmount
		WHERE [Id] = @accountId
	END

EXECUTE [dbo].usp_WithdrawMoney 5, 25

SELECT * FROM [Accounts]