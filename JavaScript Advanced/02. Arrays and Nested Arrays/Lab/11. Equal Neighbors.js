function solve(matrix) {
    let equalPairsCount = 0;

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (row + 1 < matrix.length && matrix[row][col] === matrix[row + 1][col]) {
                equalPairsCount++;
            }
            
            if (col + 1 < matrix[row].length && matrix[row][col] === matrix[row][col + 1]) {
                equalPairsCount++;
            }
        }
    }

    console.log(equalPairsCount);
}

solve([['2', '3', '4', '7', '0'],
['4', '0', '5', '3', '4'],
['2', '3', '5', '4', '2'],
['9', '8', '7', '4', '4']]);
