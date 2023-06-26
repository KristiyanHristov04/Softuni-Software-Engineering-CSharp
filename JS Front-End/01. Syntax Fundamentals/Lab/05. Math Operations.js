function solve(num01, num02, operator) {
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
        case '%':
            result = num01 % num02;
            break;
        case '**':
            result = num01 ** num02;
            break;
    }
    console.log(result);
}

solve(3, 5.5, '*');