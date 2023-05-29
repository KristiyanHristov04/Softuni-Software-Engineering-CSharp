function solve(input){
    let number = Number(input[0]);
    let sum = 0;
    let index = 1;

    while(sum < number){
        let currentNumber = Number(input[index]);
        sum += currentNumber;

        if(sum >= number){
            console.log(sum);
            break;
        }

        index++;
    }
}

// solve(['20','1','2','3','4','5','6']);