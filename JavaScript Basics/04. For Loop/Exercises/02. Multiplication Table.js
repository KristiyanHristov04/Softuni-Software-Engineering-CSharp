function solve(input){
    let number = Number(input[0]);
    for(let i = 1; i <= 10; i++){
        let num = i * number;
        console.log(`${i} * ${number} = ${num}`)
    }
}

// solve(['5']);