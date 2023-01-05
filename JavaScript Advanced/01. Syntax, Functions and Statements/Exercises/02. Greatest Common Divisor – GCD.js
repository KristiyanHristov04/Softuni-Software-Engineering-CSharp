function solve(num01, num02){
    let firstNumber = Number(num01);
    let secondNumber = Number(num02);
    let greatestDivisor = 0;

    for(let i = firstNumber; i > 0; i--){
        if(firstNumber % i == 0 && secondNumber % i == 0){
            greatestDivisor = i;
            break;
        }
    }

    console.log(greatestDivisor);
}
solve(15, 5);
solve(2154, 458);