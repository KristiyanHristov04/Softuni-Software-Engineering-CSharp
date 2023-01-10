UPDATE [Payments] 
SET [TaxRate] = [TaxRate] - ([TaxRate] * 3/100);

SELECT [TaxRate]
FROM [Payments]