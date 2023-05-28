function solve(input){
    let lillyAge = Number(input[0]);
    let washingMachinePrice = Number(input[1]);
    let toyPrice = Number(input[2]);

    let birthdayMoney = 0;
    let savedMoney = 0;
    let totalToys = 0;
    let brotherStolenMoney = 0;

    for(let i = 1; i <= lillyAge; i++){
        if(i % 2 == 0){
            birthdayMoney += 10;
            savedMoney += birthdayMoney;
            brotherStolenMoney++;
        }
        else{
            totalToys++;
        }
    }

    let soldToysIncome = totalToys * toyPrice;
    let totalSavedMoney = savedMoney + soldToysIncome - brotherStolenMoney;

    if(totalSavedMoney >= washingMachinePrice){
        let leftMoney = totalSavedMoney - washingMachinePrice;
        console.log(`Yes! ${leftMoney.toFixed(2)}`);
    }
    else{
        let neededMoney = washingMachinePrice - totalSavedMoney;
        console.log(`No! ${neededMoney.toFixed(2)}`);
    }
}

// solve(['10', '170.00', '6']);