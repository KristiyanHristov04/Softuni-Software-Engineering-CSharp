function solve(numberInput, operation01, operation02, operation03, operation04, operation05){
    let number = Number(numberInput);
    let arrayOfOperations = [operation01, operation02, operation03, operation04, operation05];
    
    for(let i = 0; i < arrayOfOperations.length; i++){
        if(arrayOfOperations[i] == 'chop'){
            number /= 2;
        }
        else if(arrayOfOperations[i] == 'dice'){
            number = Math.sqrt(number);
        }
        else if(arrayOfOperations[i] == 'spice'){
            number++;
        }
        else if(arrayOfOperations[i] == 'bake'){
            number *= 3;
        }
        else if(arrayOfOperations[i] == 'fillet'){
            number *= 0.80;
        }
        console.log(number);
    }
}
solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');
solve('9', 'dice', 'spice', 'chop', 'bake', 'fillet');