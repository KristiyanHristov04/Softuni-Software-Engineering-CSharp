function solve(input){
    if (typeof(input) == "number") {
        let result = Math.PI * input ** 2;
        console.log(result.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${typeof(input)}.`);
    }
}

solve(5);
solve('name');