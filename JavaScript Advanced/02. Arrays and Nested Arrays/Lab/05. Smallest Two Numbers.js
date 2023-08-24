function solve(array) {
    let twoLowestValueDigits = [];
    let minNumber01 = Math.min(...array);
    let firstMinIndex = array.indexOf(minNumber01);
    array.splice(firstMinIndex, 1);
    let minNumber02 = Math.min(...array);
    twoLowestValueDigits.push(minNumber01, minNumber02);
    console.log(twoLowestValueDigits.join(' '));
}

solve([30, 15, 50, 5]);