function solve(matrix) {
    let biggestNum = Number.MIN_SAFE_INTEGER;
    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            let currentNum = matrix[i][j];
            if (currentNum > biggestNum) {
                biggestNum = currentNum;
            }
        }
    }
    console.log(biggestNum);
}

solve([[3, 5, 7, 12],
[-1, 4, 33, 2],
[8, 3, 0, 4]]);
