function solve(input){
    let total = 0;
    let index = 0;

    while(true){
        let operation = input[index];

        if(operation == "NoMoreMoney"){
            console.log(`Total: ${total.toFixed(2)}`);
            break;
        }

        let increase = Number(operation);
        if(increase < 0){
            console.log("Invalid operation!");
            console.log(`Total: ${total.toFixed(2)}`);
            break;
        }

        total += increase;
        console.log(`Increase: ${increase.toFixed(2)}`);
        index++;
    }
}

// solve(['5.51', '69.42', '100', 'NoMoreMoney']);