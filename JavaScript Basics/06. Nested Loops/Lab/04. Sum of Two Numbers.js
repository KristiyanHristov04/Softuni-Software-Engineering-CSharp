function solve(input){
    let intervalStart = Number(input[0]);
    let intervalEnd = Number(input[1]);
    let magicNumber = Number(input[2]);

    let totalCombinations = 0;
    let neededCombinationPlace = 0;

    for(let i = intervalStart; i <= intervalEnd; i++){
        for(let j = intervalStart; j <= intervalEnd; j++){
            totalCombinations++;
            let result = i + j;
            if(result == magicNumber){
                neededCombinationPlace = totalCombinations;
                console.log(`Combination N:${totalCombinations} (${i} + ${j} = ${magicNumber})`);
                return;
            }
        }
    }

    console.log(`${totalCombinations} combinations - neither equals ${magicNumber}`);
}

// solve(['88', '888', '2000']);