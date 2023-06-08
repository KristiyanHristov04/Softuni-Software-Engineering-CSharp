function solve(input){
    let primeNumbersSum = 0;
    let nonPrimeNumbersSum = 0;
    for(i = 0; i < input.length; i++){
        let isPrimeNumber = true;
        let currentValue = input[i];
        if(currentValue == 'stop'){
            break;
        }
        let currentNumber = Number(currentValue);
        if(currentNumber < 0){
            console.log('Number is negative.');
            continue;
        }
        for(let j = 2; j <= currentNumber; j++){
            if(j != currentNumber && currentNumber % j == 0){
                isPrimeNumber = false;
                break;
            }
        }
        if(isPrimeNumber){
            primeNumbersSum += currentNumber;
        }
        else{
            nonPrimeNumbersSum += currentNumber;
        }
    }
    console.log(`Sum of all prime numbers is: ${primeNumbersSum}`);
    console.log(`Sum of all non prime numbers is: ${nonPrimeNumbersSum}`);
}

// solve(['30',
// '83',
// '33',
// '-1',
// '20',
// 'stop']);
