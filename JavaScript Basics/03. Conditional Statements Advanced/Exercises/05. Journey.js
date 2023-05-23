function solve(input){
    let budget = Number(input[0]);
    let season = input[1];
    let moneyFromBudgetThatCanSpend = 0;

    if(budget <= 100){
        if(season == 'summer'){
            moneyFromBudgetThatCanSpend = budget * 30 / 100;
            console.log(`Somewhere in Bulgaria`);
            console.log(`Camp - ${moneyFromBudgetThatCanSpend.toFixed(2)}`);
        }
        else{
            moneyFromBudgetThatCanSpend = budget * 70 / 100;
            console.log(`Somewhere in Bulgaria`);
            console.log(`Hotel - ${moneyFromBudgetThatCanSpend.toFixed(2)}`);
        }
    }
    else if(budget > 100 && budget <= 1000){
        if(season == 'summer'){
            moneyFromBudgetThatCanSpend = budget * 40 / 100;
            console.log(`Somewhere in Balkans`);
            console.log(`Camp - ${moneyFromBudgetThatCanSpend.toFixed(2)}`);
        }
        else{
            moneyFromBudgetThatCanSpend = budget * 80 / 100;
            console.log(`Somewhere in Balkans`);
            console.log(`Hotel - ${moneyFromBudgetThatCanSpend.toFixed(2)}`);
        }
    }
    else{
        moneyFromBudgetThatCanSpend = budget * 90 / 100;
        console.log(`Somewhere in Europe`);
        console.log(`Hotel - ${moneyFromBudgetThatCanSpend.toFixed(2)}`);
    }
}

// solve(['312', 'summer']);