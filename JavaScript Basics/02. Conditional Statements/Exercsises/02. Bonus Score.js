function solve(input){
    let points = Number(input[0]);
    let bonus = 0;
    if(points <= 100){
        bonus += 5;
    }
    else if(points > 100 && points <= 1000){
        bonus += points * 0.20;
    }
    else if(points > 1000){
        bonus += points * 0.10;
    }

    if(points % 2 == 0){
        bonus += 1;
    }
    else if(points % 10 == 5){
        bonus += 2;
    }

    console.log(bonus);
    console.log(points + bonus);
}

// solve((['20']));
// solve((['175']));
// solve((['2703']));
// solve((['15875']));