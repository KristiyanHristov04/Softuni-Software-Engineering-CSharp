function solve(input){
    let groupBudget = Number(input[0]);
    let season = input[1];
    let numberOfFishmen = Number(input[2]);

    let totalPrice = 0;

    if(season == 'Spring'){
        totalPrice += 3000;
    }
    else if(season == 'Winter'){
        totalPrice += 2600;
    }
    else{
        totalPrice += 4200;
    }

    if(numberOfFishmen <= 6){
        totalPrice *= 0.90;
    }
    else if(numberOfFishmen >= 7 && numberOfFishmen <= 11){
        totalPrice *= 0.85;
    }
    else{
        totalPrice *= 0.75;
    }

    if(numberOfFishmen % 2 == 0 && season != 'Autumn'){
        totalPrice *= 0.95;
    }

    let leftMoney = groupBudget - totalPrice;

    if(leftMoney >= 0){
        console.log(`Yes! You have ${leftMoney.toFixed(2)} leva left.`);
    }
    else{
        let neededMoney = Math.abs(leftMoney);
        console.log(`Not enough money! You need ${neededMoney.toFixed(2)} leva.`);
    }
}

// solve(['2000', 'Winter', '13']);