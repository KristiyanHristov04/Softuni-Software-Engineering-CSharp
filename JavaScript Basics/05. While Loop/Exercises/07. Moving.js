function solve(input){
    let freeSpaceWidth = Number(input[0]);
    let freeSpaceLength = Number(input[1]);
    let freeSpaceHeight = Number(input[2]);

    let totalFreeSpace = freeSpaceHeight * freeSpaceLength * freeSpaceWidth;
    let currentTakenSpace = 0;
    let index = 3;
    while(true){
        let action = input[index];
        if(action == 'Done'){
            let cubicMetersLeft = totalFreeSpace - currentTakenSpace;
            console.log(`${cubicMetersLeft} Cubic meters left.`);
            return;
        }
        let cubicMeters = Number(action);
        currentTakenSpace += cubicMeters;
        if(currentTakenSpace > totalFreeSpace){
            let neededCubicMeters = currentTakenSpace - totalFreeSpace;
            console.log(`No more free space! You need ${neededCubicMeters} Cubic meters more.`);
            return;
        }
        index++;
    }
}

// solve(['10','10','2','20','20','20','20','122']);
solve(['10','1','2','4', '6','Done']);
