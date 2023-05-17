function solve(input){
    let filmBudget = Number(input[0]);
    let extrasCount = Number(input[1]);
    let wearPerExtraPrice = Number(input[2]);

    let decorPrice = filmBudget * 0.10;
    let expenses = extrasCount * wearPerExtraPrice;
    if(extrasCount > 150){
        expenses = expenses * 0.90;
    }

    totalExpenses = expenses + decorPrice;

    let leftMoney = filmBudget - totalExpenses;
    if(leftMoney >= 0){
        console.log(`Action!\nWingard starts filming with ${leftMoney.toFixed(2)} leva left.`);
    }
    else{
        console.log(`Not enough money!\nWingard needs ${(Math.abs(leftMoney)).toFixed(2)} leva more.`);
    }
}

solve(['20000','120','55.5']);
solve(['15437.62','186','57.99']);
solve(['9587.88','222','55.68']);