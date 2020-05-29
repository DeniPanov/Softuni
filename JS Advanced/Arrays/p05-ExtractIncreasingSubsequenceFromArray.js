"use strict"

function solve(input){
    let myArr = input.slice();
    let maxNum = myArr[0];

    myArr
    .map((x, index,  arr) => x >= maxNum ? maxNum = x : arr.splice(index, 1, -1));

    return myArr
    .filter(x => x !== -1)
    .join("\n");
}