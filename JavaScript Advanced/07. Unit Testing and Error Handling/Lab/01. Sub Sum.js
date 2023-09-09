function solve(array, startIndex, endIndex) {
    let sum = 0;

    if (!Array.isArray(array)) {
        sum = NaN;
    }

    if (endIndex > array.length - 1) {
        endIndex = array.length - 1;
    }

    if (startIndex < 0) {
        startIndex = 0;
    }

    for (let index = startIndex; index <= endIndex; index++) {
        sum += Number(array[index]);
    }

    return sum;
}

console.log(solve([10, 20, 30, 40, 50, 60], 3, 300));
console.log(solve([1.1, 2.2, 3.3, 4.4, 5.5], -3, 1));
console.log(solve([10, 'twenty', 30, 40], 0, 2));
console.log(solve([], 1, 2));
console.log(solve('text', 0, 2));