function solve(input) {
    let allEvenIndexedNumbers = [];
    for (let index = 0; index < input.length; index++) {
        if (index % 2 === 0) {
            allEvenIndexedNumbers.push(input[index]);
        }
    }

    console.log(allEvenIndexedNumbers.join(' '));
}

solve(['20', '30', '40',
    '50', '60']);