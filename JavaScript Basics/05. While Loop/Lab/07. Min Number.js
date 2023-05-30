function solve(input){
    let smallestNumber = Number.MAX_SAFE_INTEGER;
    let index = 0;

    while(true){
        let operation = input[index];

        if(operation == 'Stop'){
            break;
        }

        let number = Number(operation);

        if(number < smallestNumber){
            smallestNumber = number;
        }

        index++;
    }

    console.log(smallestNumber);
}

solve(['-10','20','-30','Stop']);