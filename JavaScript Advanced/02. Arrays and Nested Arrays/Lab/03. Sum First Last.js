function solve(array) {
    let first = Number(array.shift());
    let last = Number(array.pop());
    return first + last;
}

solve(['20', '30', '40'] );