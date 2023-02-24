CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(18, 4))
AS
	IF(@amount < 0)
	THROW 50001, 'Invalid Amount', 1
	BEGIN TRANSACTION
		BEGIN TRY
			EXEC [dbo].usp_WithdrawMoney @senderId, @amount
			EXEC [dbo].usp_DepositMoney  @receiverId, @amount
		END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION
	END CATCH
	COMMIT TRANSACTION

EXEC usp_TransferMoney 5, 1, 5000

SELECT * FROM [Accounts]