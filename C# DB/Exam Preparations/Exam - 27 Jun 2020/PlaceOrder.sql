CREATE PROC usp_PlaceOrder
(@jobId INT, @serial VARCHAR(50), @quantity INT)
AS
BEGIN
IF (@jobId IN (SELECT JobId FROM Jobs WHERE Status = 'Finished')) THROW 50011, 'This job is not active!', 1
IF (@quantity <= 0) THROW 50012, 'Part quantity must be more than zero!', 1
IF (@jobId NOT IN (SELECT JobId FROM Jobs)) THROW 50013, 'Job not found!', 1
IF (@serial NOT IN (SELECT SerialNumber FROM Parts)) THROW 50014, 'Part not found!', 1

DECLARE @partId INT = (SELECT TOP(1) PartId FROM Parts WHERE SerialNumber = @serial)
DECLARE @orderId INT

IF (@jobId IN (SELECT JobId FROM Orders WHERE IssueDate IS NULL))
    BEGIN
    SET @OrderId = (SELECT TOP(1) OrderId FROM Orders WHERE JobId = @jobId)
    IF (@partId IN (SELECT PartId FROM OrderParts WHERE OrderId = @OrderId))
        BEGIN
        UPDATE OrderParts
            SET Quantity += @quantity 
            WHERE OrderId = @OrderId AND PartId = @partId
        RETURN
        END
    INSERT INTO OrderParts VALUES (@OrderId, @partId, @quantity)
    RETURN
    END

INSERT INTO Orders VALUES (@jobId, NULL, 0)
SET @orderId = (SELECT TOP(1) OrderId FROM Orders ORDER BY OrderId DESC)
INSERT INTO OrderParts VALUES (@OrderId, @partId, @quantity)
END

GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH
