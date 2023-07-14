function palindromeNumbers(numbers){
    for (let i = 0; i < numbers.length; i++) {
        let currentDigitAsString = numbers[i].toString();
        let currentDigitAsStringReversed = '';
        for (let j = currentDigitAsString.length - 1; j >= 0; j--) {
            currentDigitAsStringReversed += currentDigitAsString[j];
        }
        if(currentDigitAsString === currentDigitAsStringReversed){
            console.log(true);
        } else {
            console.log(false);
        }
    }
}

palindromeNumbers([123,323,421,121]);