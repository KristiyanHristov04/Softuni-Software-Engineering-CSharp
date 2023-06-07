function solve(input){
    let start = Number(input[0]);
    let end = Number(input[1]);
    let printLine = '';

    for(let i = start; i <= end; i++){
        let numberAsString = i.toString();
        let evenSum = 0;
        let oddSum = 0;
        for(j = 0; j < numberAsString.length; j++){
            let digit = Number(numberAsString[j]);
            if(j % 2 == 0){
                evenSum += digit;
            }
            else{
                oddSum += digit;
            }
        }

        if(evenSum == oddSum){
            printLine += numberAsString + ' ';
        }
    }

    console.log(printLine);
}

// solve(['100000', '100050']);