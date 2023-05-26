function solve(input) {
    let power = Number(input[0]);
    let number = 1;

    for (let i = 0; i <= power; i += 2) {
        console.log(number);
        number = number * 2 * 2;
    }
}

// solve(['7']);