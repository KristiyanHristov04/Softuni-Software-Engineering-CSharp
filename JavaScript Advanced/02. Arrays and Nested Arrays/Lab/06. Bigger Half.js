function solve(array) {
    let sortedArray = array.sort((a, b) => a - b);
    let arrayLength = sortedArray.length;
    let indexMid = Math.floor(arrayLength / 2);
    let secondHalfArray = sortedArray.splice(indexMid);
    return secondHalfArray;
}

solve([4, 7, 2, 5, 6]);