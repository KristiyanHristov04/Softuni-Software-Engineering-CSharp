function factorialDivision(firstNumber, secondNumber) {
    let firstNumberFactorial = factorial(firstNumber);
    let secondNumberFactorial = factorial(secondNumber);
    let result = firstNumberFactorial / secondNumberFactorial;
    console.log(result.toFixed(2));

    function factorial(n) {
        if (n == 1) {
            return 1;
        }
        return n * factorial(n - 1);
    }
}

factorialDivision(5, 2);