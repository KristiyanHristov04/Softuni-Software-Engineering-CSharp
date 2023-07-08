function solve(num01, operator, num02) {
    let result = 0;
    switch (operator) {
        case '+':
        result = num01 + num02;
            break;
        case '-':
            result = num01 - num02;
            break;
        case '*':
            result = num01 * num02;
            break;
        case '/':
            result = num01 / num02;
            break;
    }
    console.log(result.toFixed(2));
}

solve(5, '+', 10);