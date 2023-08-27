function solve(matrix) {
    let mainDiagonalSum = 0;
    let secondaryDiagonalSum = 0;
    let mainIndex = 0;
    let secondaryIndex = matrix[0].length - 1;

    for (let i = 0; i < matrix.length; i++) {
        let currentRowLength = matrix[i].length;
        mainDiagonalSum += matrix[i][mainIndex];
        mainIndex++;
        secondaryDiagonalSum += matrix[i][secondaryIndex];
        secondaryIndex--;
    }

    console.log(mainDiagonalSum + ' ' + secondaryDiagonalSum);
}

// solve([
//     [20, 40],
//     [10, 60]
// ]);

solve([[3, 5, 17], [-1, 7, 14],
[1, -8, 89]]
)