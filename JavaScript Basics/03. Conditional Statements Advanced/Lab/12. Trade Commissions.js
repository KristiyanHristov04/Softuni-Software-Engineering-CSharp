function solve(input){
    let townName = input[0];
    let sells = Number(input[1]);
    let commission = 0;

    if(townName == 'Sofia' && sells >= 0){
        if(sells >= 0 && sells <= 500){
            commission = sells * (5 / 100);
        }
        else if(sells > 500 && sells <= 1000){
            commission = sells * (7 / 100);
        }
        else if(sells > 1000 && sells <= 10000){
            commission = sells * (8 / 100);
        }
        else{
            commission = sells * (12 / 100);
        }
    }
    else if(townName == 'Varna' && sells >= 0){
        if(sells >= 0 && sells <= 500){
            commission = sells * (4.5 / 100);
        }
        else if(sells > 500 && sells <= 1000){
            commission = sells * (7.5 / 100);
        }
        else if(sells > 1000 && sells <= 10000){
            commission = sells * (10 / 100);
        }
        else{
            commission = sells * (13 / 100);
        }
    }
    else if(townName == 'Plovdiv' && sells >= 0){
        if(sells >= 0 && sells <= 500){
            commission = sells * (5.5 / 100);
        }
        else if(sells > 500 && sells <= 1000){
            commission = sells * (8 / 100);
        }
        else if(sells > 1000 && sells <= 10000){
            commission = sells * (12 / 100);
        }
        else{
            commission = sells * (14.5 / 100);
        }
    }
    else{
        console.log('error');
        return;
    }
    console.log(commission.toFixed(2));
}

solve(['Kaspichan', '-50']);