function solve(input){
    let inputAsString = input + '';
    let sum = 0;
    for (let index = 0; index < inputAsString.length; index++) {
        let currentNumber = Number(inputAsString[index]);
        sum += currentNumber;
    }
    console.log(sum);
}

solve(245678);