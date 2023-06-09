function solve(input){
    let n = Number(input[0]);
    let printLine = '';
    for(let i = 1111; i <= 9999; i++){
        let isSpecialNumber = true;
        let numberAsString = '' + i;
        for(let j = 0; j < numberAsString.length; j++){
            let currentDigitValue = Number(numberAsString[j]);
            if(n % currentDigitValue != 0){
                isSpecialNumber = false;
                break;
            }
        }
        if(isSpecialNumber){
            printLine += numberAsString + ' ';
        }
    }
    console.log(printLine);
}

// solve(['3']);