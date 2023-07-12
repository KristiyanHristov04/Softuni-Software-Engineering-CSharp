function solve(num01, num02, num03){
    let firstNumberAsString = num01.toString();
    let secondNumberAsString = num02.toString();
    let thirdNumberAsString = num03.toString();
    const totalMinusSymbols = function (){
        let count = 0;
        if(firstNumberAsString.includes('-')){
            count++;
        }
        if(secondNumberAsString.includes('-')){
            count++;
        }
        if(thirdNumberAsString.includes('-')){
            count++;
        }

        if(count == 0){
            return 'Positive';
        } else if (count == 1 || count == 3) {
            return 'Negative';
        } else {
            return 'Positive';
        }
    }
    console.log(totalMinusSymbols());
}

solve(-1, -2, -3);