function solve(input){
    let firstNumber = input.shift();
    let lastNumber = input.pop();
    let result = firstNumber + lastNumber;
    console.log(result);
}

solve([10, 17, 22, 33]);