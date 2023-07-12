function solve(number01, number02, operator) {
    
    const addFunc = () => number01 + number02;
    const subtractFunc = () => number01 - number02;
    const multiplyFunc = () => number01 * number02;
    const divideFunc = () => number01 / number02;
    
    switch (operator) {
        case 'add':
            console.log(addFunc());
            break;
        case 'subtract':
            console.log(subtractFunc());
            break;
        case 'multiply':
            console.log(multiplyFunc());
            break;
        case 'divide':
            console.log(divideFunc());
            break;
    }
}

solve(3, 2, 'multiply');


