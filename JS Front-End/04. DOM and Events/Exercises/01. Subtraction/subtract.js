function subtract() {
    let result = document.getElementById('result');
    let firstValue = document.getElementById('firstNumber').value;
    let secondValue = document.getElementById('secondNumber').value;
    let sum = Number(firstValue) - Number(secondValue);
    result.textContent = sum;
}