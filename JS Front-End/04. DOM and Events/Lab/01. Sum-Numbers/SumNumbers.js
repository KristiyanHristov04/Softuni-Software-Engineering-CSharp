function calc() {
    let firstInput = document.getElementById('num1').value;
    let secondInput = document.getElementById('num2').value;
    let sum = document.getElementById('sum');
    sum.value = Number(firstInput) + Number(secondInput);
}
