function depositCalculator(input){
    let depositSum = Number(input[0]);
    let depositPeriodInMonths = Number(input[1]);
    let yearPercent = Number(input[2]);

    let temp = depositSum * (yearPercent / 100);
    let temp2 = temp / 12;
    let totalSum = depositSum + depositPeriodInMonths * temp2;
    console.log(totalSum);
}

depositCalculator(['200', '3', '5.7']);
depositCalculator(['2350', '6', '7']);