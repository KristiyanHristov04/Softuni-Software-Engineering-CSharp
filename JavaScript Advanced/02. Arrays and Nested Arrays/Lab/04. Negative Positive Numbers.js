function solve(array) {
    let fixedArray = [];
    for (let index = 0; index < array.length; index++) {
        if (array[index] < 0) {
            fixedArray.unshift(array[index]);
        } else {
            fixedArray.push(array[index]);
        }
    }

    console.log(fixedArray.join('\n'));
}

solve([3, -2, 0, -1]);