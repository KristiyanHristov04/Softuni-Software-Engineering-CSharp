function solve(input){
    let numberAsString = input + '';
    let firstLetter = numberAsString[0];
    let sum = 0;
    let areAllTheSame = true;
    for (let index = 0; index < numberAsString.length; index++) {
        if(firstLetter != numberAsString[index]){
            areAllTheSame = false;
        }
        sum += Number(numberAsString[index]);
    }
    console.log(areAllTheSame);
    console.log(sum);
}

solve(1234);