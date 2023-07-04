function solve(num, param01, param02, param03, param04, param05){
    let number = Number(num);
    let input = [];
    input.push(param01);
    input.push(param02);
    input.push(param03);
    input.push(param04);
    input.push(param05);
    for (let index = 0; index < input.length; index++) {
        let currentOperation = input[index];
        if(currentOperation == 'chop'){
            number /= 2;
        } else if(currentOperation == 'dice'){
            number = Math.sqrt(number);
        } else if(currentOperation == 'spice'){
            number++;
        } else if(currentOperation == 'bake'){
            number *= 3;
        } else {
            number *= 0.80;
        }
        console.log(number);
    }
}

solve('32', 'chop', 'chop', 'chop', 'chop', 'chop');