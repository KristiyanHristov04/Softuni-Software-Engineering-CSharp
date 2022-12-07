function solve(input){
    const array = input;
    let arraySum = 0;
    let concatElements = '';
    let inverseElementsSum = 0;

    for (let index = 0; index < array.length; index++) {
        arraySum += array[index];
        concatElements += array[index];
        inverseElementsSum += 1 / array[index];
    }

    console.log(arraySum);
    console.log(inverseElementsSum);
    console.log(concatElements);

}

solve([1, 2, 3])
solve([2, 4, 8, 16])