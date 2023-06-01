function solve(input){
    let neededMoneyForTrip = Number(input[0]);
    let currentMoney = Number(input[1]);
    let index = 2;
    let totalDays = 0;
    let daysOnlySpending = 0;

    while(true){
        let action = input[index];
        if(action == 'spend'){
            let moneyToSpend = Number(input[index + 1]);
            currentMoney -= moneyToSpend;
            if(currentMoney < 0){
                currentMoney = 0;
            }
            totalDays++;
            daysOnlySpending++;
        }
        else if(action == 'save'){
            let moneyToSave = Number(input[index + 1]);
            currentMoney += moneyToSave;
            totalDays++;
            daysOnlySpending = 0;
        }

        if(daysOnlySpending == 5){
            console.log(`You can't save the money.`);
            console.log(`${totalDays}`);
            return;
        }

        if(currentMoney >= neededMoneyForTrip){
            console.log(`You saved the money for ${totalDays} days.`);
            return;
        }

        index += 2;
    }
}

// solve(['2000','1000','spend','1200','save','2000']);
// solve(['110','60','spend','10','spend','10','spend','10','spend','10','spend','10']);
// solve(['250','150','spend','50','spend','50','save','100','save','100']);