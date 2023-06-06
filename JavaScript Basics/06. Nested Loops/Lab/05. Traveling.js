function solve(input){
    let arrayLength = input.length;
    let currentSavedMoney = 0;
    let destinationToGo = '';
    let neededMoney = 0;
    let isLookingForDestination = true;

    for(let i = 0; i < arrayLength; i++){
        if(currentSavedMoney == 0 && input[i] != 'End' && isLookingForDestination){
            destinationToGo = input[i];
            isLookingForDestination = false;
        }
        else if(currentSavedMoney == 0 && input[i] != 'End' && !isLookingForDestination && neededMoney == 0){
            neededMoney = Number(input[i]);
        }
        else if(input[i] == 'End'){
            return;
        }
        else{
            let moneyToSave = Number(input[i]);
            currentSavedMoney += moneyToSave;
            if(currentSavedMoney >= neededMoney){
                console.log(`Going to ${destinationToGo}!`);
                isLookingForDestination = true;
                neededMoney = 0;
                currentSavedMoney = 0;
            }
        }
    }
}

// solve(['Greece',
// '1000',
// '200',
// '200',
// '300',
// '100',
// '150',
// '240',
// 'Spain',
// '1200',
// '300',
// '500',
// '193',
// '423',
// 'End']);