function solve(firstNum, secondNum){
    let num01 = Number(firstNum);
    let num02 = Number(secondNum);

    let totalSum = 0;

    for (let index = num01; index <= num02; index++) {
        totalSum += index;
    }

    return totalSum;
}

let result = solve(5, 7);
console.log(result);