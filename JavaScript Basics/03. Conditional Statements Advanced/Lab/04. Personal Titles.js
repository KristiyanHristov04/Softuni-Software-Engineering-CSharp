function solve(input) {
    let age = Number(input[0]);
    let gender = input[1];

    if (gender == 'm') {
        if (age >= 16) {
            console.log('Mr.');
        }
        else {
            console.log('Master');
        }
    }
    else {
        if (age >= 16) {
            console.log('Ms.');
        }
        else {
            console.log('Miss');
        }
    }
}

// solve(['12', 'f']);