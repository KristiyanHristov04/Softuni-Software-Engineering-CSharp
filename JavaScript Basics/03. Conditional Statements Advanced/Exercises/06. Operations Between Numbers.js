function solve(input) {
    let firstNumber = Number(input[0]);
    let secondNumber = Number(input[1]);
    let operation = input[2];

    let result = 0;

    switch (operation) {
        case '+':
            result = firstNumber + secondNumber;
            console.log(`${firstNumber} + ${secondNumber} = ${result} - ${result % 2 == 0 ? 'even' : 'odd'}`);
            break;
        case '-':
            result = firstNumber - secondNumber;
            console.log(`${firstNumber} - ${secondNumber} = ${result} - ${result % 2 == 0 ? 'even' : 'odd'}`);
            break;
        case '*':
            result = firstNumber * secondNumber;
            console.log(`${firstNumber} * ${secondNumber} = ${result} - ${result % 2 == 0 ? 'even' : 'odd'}`);
            break;
        case '%':
            if(secondNumber != 0){
                result = firstNumber % secondNumber;
                console.log(`${firstNumber} % ${secondNumber} = ${result}`);
            }
            else{
                console.log(`Cannot divide ${firstNumber} by zero`);
            }
            break;
        case '/':
            if(secondNumber != 0){
                result = firstNumber / secondNumber;
                console.log(`${firstNumber} / ${secondNumber} = ${result.toFixed(2)}`);
            }
            else{
                console.log(`Cannot divide ${firstNumber} by zero`);
            }
            break;
    }
}

// solve(['10', '0', '%']);
