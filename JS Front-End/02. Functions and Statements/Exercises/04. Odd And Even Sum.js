function oddAndEvenDigitsSum(number){
    let numberAsString = number.toString();
    let evenDigitsSum = 0;
    let oddDigitsSum = 0;

    for (let i = 0; i < numberAsString.length; i++) {
        let currentDigit = Number(numberAsString[i]);
        if(currentDigit % 2 == 0){
            evenDigitsSum += currentDigit;
        } else {
            oddDigitsSum += currentDigit;
        }
    }

    console.log(`Odd sum = ${oddDigitsSum}, Even sum = ${evenDigitsSum}`);
}

oddAndEvenDigitsSum(1000435);