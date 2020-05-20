"use strict";

function solve(x){
    x = x.toString()
        .split("");

    let firstNumber = x[0];
    hasSameNumbers = x.some(x => x !== firstNumber);

    let sum = x
        .map(Number)
        .reduce((a, c) => (a + c));

    console.log(!hasSameNumbers);
    console.log(sum);
}

solve(2222222);
solve(1234);