function solve(input){
    let biggestNumber = Number.MIN_SAFE_INTEGER;
    let index = 0;

    while(true){
        let operation = input[index];

        if(operation == 'Stop'){
            break;
        }

        let number = Number(operation);

        if(number > biggestNumber){
            biggestNumber = number;
        }

        index++;
    }

    console.log(biggestNumber);
}

// solve(['-1', '-2', 'Stop']);