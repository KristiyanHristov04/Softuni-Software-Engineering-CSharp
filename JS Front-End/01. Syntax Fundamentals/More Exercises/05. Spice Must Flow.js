function solve(yield){
    let totalDays = 0;
    let totalSpiceExtracted = 0;

    while(yield >= 100){
        totalSpiceExtracted += yield;
        totalSpiceExtracted -= 26;
        totalDays++;
        yield -= 10;
        if(yield < 100){
            totalSpiceExtracted -= 26;
            break;
        }
    }

    console.log(totalDays);
    console.log(totalSpiceExtracted);
}

solve(111);
solve(450);