function solve(input){
    const stepsToMake = 10_000;
    let madeStepsToday = 0;
    let index = 0;
    while(true){
        let action = input[index];
        if(action == 'Going home'){
            let lastSteps = Number(input[index + 1]);
            madeStepsToday += lastSteps;
            if(madeStepsToday >= stepsToMake){
                console.log(`Goal reached! Good job!`);
                let stepsOver = madeStepsToday - stepsToMake;
                console.log(`${stepsOver} steps over the goal!`);
            }
            else{
                let moreStepsToReachGoal = stepsToMake - madeStepsToday;
                console.log(`${moreStepsToReachGoal} more steps to reach goal.`);
            }
            return;
        }
        else{
            let steps = Number(action);
            madeStepsToday += steps;
            if(madeStepsToday >= stepsToMake){
                console.log(`Goal reached! Good job!`);
                let stepsOver = madeStepsToday - stepsToMake;
                console.log(`${stepsOver} steps over the goal!`);
                return;
            }
        }
        index++;
    }
}

// solve(['1000','1500','2000','6500']);