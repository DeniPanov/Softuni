"use strict"

function solve(matrix) {

    function getRowSum(row) {
        return row.reduce((a, c) => a + c);
    }

    const reverseMatrix = matrix.map((col, i) => matrix.map(row => row[i]));
    const firstRowSum = getRowSum(matrix[0]);
    let isMagicMatrix = true;

    for (let i = 0; i < matrix.length; i++) {
        if (getRowSum(matrix[i]) !== firstRowSum || getRowSum(reverseMatrix[i]) !== firstRowSum) {
            isMagicMatrix = false;
            break;
        }
    }

    return isMagicMatrix;
}

console.log(solve([[4, 5, 6],
[6, 5, 4],
[5, 5, 5]]));

console.log(solve([[11, 32, 45],
[21, 0, 1],
[21, 1, 1]]));

console.log(solve([[1, 0, 0],
[0, 0, 1],
[0, 1, 0]]));