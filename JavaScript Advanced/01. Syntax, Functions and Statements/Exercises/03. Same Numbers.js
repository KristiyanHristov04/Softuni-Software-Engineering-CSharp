function solve(input){
    let number = String(input);
    let firstDigit = number[0];
    let areSame = true;
    for (let index = 1; index <= number.length - 1; index++) {
        if(firstDigit != number[index]){
            areSame = false;
            break;
        }
    }

    let sumOfDigits = 0;
    for (let index = 0; index < number.length; index++) {
        sumOfDigits += Number(number[index]);
    }

    console.log(areSame);
    console.log(sumOfDigits);
}

solve(2222222);
solve(1234);