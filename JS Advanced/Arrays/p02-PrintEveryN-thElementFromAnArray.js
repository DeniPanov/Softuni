"use strict";

function solve(input) {
    let arr = input.slice();
    let step = Number(arr.pop());
    return arr.filter((_, i) => i % step === 0).join("\n");
}

console.log(solve(['5','20','31','4','20','2']));
console.log(solve(['dsa','asd','test','tset','2']));
console.log(solve(['1','2','3','4','5','6']));