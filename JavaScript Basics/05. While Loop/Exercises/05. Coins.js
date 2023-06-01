function solve(input){
    let change = Number(input[0]);
    let coins = 0;
    while(change > 0){
        if(change - 2 >= 0){
            change -= 2;
        }
        else if(change - 1 >= 0){
            change -= 1;
        }
        else if(change - 0.50 >= 0){
            change -= 0.50;
        }
        else if(change - 0.20 >= 0){
            change -= 0.20;
        }
        else if(change - 0.10 >= 0){
            change -= 0.10;
        }
        else if(change - 0.05 >= 0){
            change -= 0.05;
        }
        else if(change - 0.02 >= 0){
            change -= 0.02;
        }
        else if(change - 0.01 >= 0){
            change -= 0.01;
        }
        change = change.toFixed(2);
        coins++;
    }
    console.log(coins);
}

// solve(['2.73']);