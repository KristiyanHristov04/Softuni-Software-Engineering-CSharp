function solve(input){
    let number = input[0];
    let digitsSum = 0;
    for(let i = 0; i < number.length; i++){
        let currentDigit = Number(number[i]);
        digitsSum += currentDigit;
    }
    console.log(`The sum of the digits is:${digitsSum}`);
}

// solve(['1234']);