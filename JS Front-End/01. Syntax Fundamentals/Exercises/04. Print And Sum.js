function solve(num01, num02){
    let sum = 0;
    let array = [];
    for (let index = num01; index <= num02; index++) {
        sum += index;
        array.push(index);
    }
    console.log(array.join(' '));
    console.log(`Sum: ${sum}`);
}

solve(0, 26);