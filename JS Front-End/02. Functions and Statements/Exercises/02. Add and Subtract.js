function solve(num01, num02, num03){
    let subtractResult = subtract(num03);
    console.log(subtractResult);
    
    function sum(firstNumber, secondNumber){
        return firstNumber + secondNumber;
    }

    function subtract(thirdNumber){
        return sum(num01, num02) - thirdNumber;
    }
}

solve(23, 6, 10);
// solve(1, 17, 30);