function solve(input){
    let evenSum = 0;
    let oddSum = 0;
    for (let index = 0; index < input.length; index++) {
        if(input[index] % 2 == 0){
            evenSum += input[index];
        } else {
            oddSum += input[index];
        }
    }
    let difference = evenSum - oddSum;
    console.log(difference);
}

solve([1, 2, 3, 4, 5, 6]);