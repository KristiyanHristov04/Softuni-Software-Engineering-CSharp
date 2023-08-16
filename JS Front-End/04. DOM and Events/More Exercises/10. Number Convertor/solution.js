function solve() {
    let decimalNumber = document.getElementById('input');
    const selectMenuTo = document.getElementById('selectMenuTo');
    const convertButton = document.getElementsByTagName('button')[0];
    const result = document.getElementById('result');

    let binaryOption = document.createElement('option');
    let hexadecimalOption = document.createElement('option');
    binaryOption.textContent = 'Binary';
    hexadecimalOption.textContent = 'Hexadecimal';
    binaryOption.setAttribute('value', 'binary');
    hexadecimalOption.setAttribute('value', 'hexadecimal');
    selectMenuTo.appendChild(binaryOption);
    selectMenuTo.appendChild(hexadecimalOption);

    
    convertButton.addEventListener('click', convert);

    function convert() {
        let selectedValue = selectMenuTo.value;
        if (selectedValue === 'binary') {
            convertDecimalToBinary(decimalNumber);
        } else if (selectedValue === 'hexadecimal') {
            convertDecimalToHexadecimal(decimalNumber);
        }
    }

    function convertDecimalToBinary(decimalNumber) {
        let number = Number(decimalNumber.value);
        let binary = number.toString(2);
        result.value = binary;
    }

    function convertDecimalToHexadecimal(decimalNumber) {
        let number = Number(decimalNumber.value);
        let binary = number.toString(16).toUpperCase();
        result.value = binary;
    }
}