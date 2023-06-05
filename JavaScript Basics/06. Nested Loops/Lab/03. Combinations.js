function solve(input){
    let n = Number(input[0]);
    let totalCombinations = 0;

    for(let i = 0; i <= n; i++){
        for(let j = 0; j <= n; j++){
            for(let k = 0; k <= n; k++){
                let result = i + j + k;
                if(result == n){
                    totalCombinations++;
                }
            }
        }
    }

    console.log(totalCombinations);
}

// solve(['20']);