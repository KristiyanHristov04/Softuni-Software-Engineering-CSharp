function solve(array) {
    let newArray = [];
    for (let index = array.length - 1; index >= 0; index--) {
        if (index % 2 !== 0) {
            newArray.push(array[index] * 2);
        }
    }
    console.log(newArray.join('\n'));
}

solve([3, 0, 10, 4, 7, 3]);