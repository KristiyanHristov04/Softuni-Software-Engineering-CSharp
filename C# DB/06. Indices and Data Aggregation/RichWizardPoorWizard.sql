SELECT SUM([Host Wizard Deposit] - [Guest Wizard Deposit])
	AS [SumDifference]
	FROM (
		SELECT [FirstName]
		AS [Host Wizard],
			[DepositAmount]
		AS [Host Wizard Deposit],
			LEAD([FirstName]) OVER (ORDER BY [Id])
		AS [Guest Wizard],
			LEAD([DepositAmount]) OVER (ORDER BY [Id])
		AS [Guest Wizard Deposit]
		FROM [WizzardDeposits]
		) AS [HostGuestWizardQuery]
WHERE [Guest Wizard] IS NOT NULL