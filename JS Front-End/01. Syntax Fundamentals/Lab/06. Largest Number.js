function solve(num01, num02, num03){
    if(num01 > num02){
        if(num01 > num03){
            console.log(`The largest number is ${num01}.`);
            return;
        }
        console.log(`The largest number is ${num03}.`);
    }
    else if(num02 > num03){
        console.log(`The largest number is ${num02}.`);
    }
    else{
        console.log(`The largest number is ${num03}.`);
    }
}

solve(-3, -5, -22.5);