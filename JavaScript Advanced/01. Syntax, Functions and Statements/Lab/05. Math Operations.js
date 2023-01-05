function solve(num01, num02, operator) {
    let result;
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

        default:
            break;
    }
    console.log(result);
}

solve(5, 6, '+');
solve(3, 5.5, '*');
solve(2, 3, '**');