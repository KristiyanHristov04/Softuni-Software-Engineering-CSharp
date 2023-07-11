function solve(number, power){
    let result = 1;
    for (let index = 1; index <= power; index++) {
        result *= number;
    }
    console.log(result);
}

solve(3, 4);

