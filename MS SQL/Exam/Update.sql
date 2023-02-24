UPDATE [PlayersRanges]
SET [PlayersMax] += 1
WHERE [PlayersMin] = 2 AND [PlayersMax] = 2


UPDATE [Boardgames]
SET [Name] = [Name] + 'V2'
WHERE [YearPublished] >= 2020