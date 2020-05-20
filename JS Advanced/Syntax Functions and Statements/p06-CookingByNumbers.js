"use strict";

function solve(input){
let number = Number(input[0]);

let operations = {
    chop: (x) => x / 2,
    dice: (x) => Math.sqrt(x),
    spice: (x) => ++x,
    bake: (x) => x *= 3,
    fillet: (x) => x * 0.8, 
}

for (let i = 1; i < input.length; i++) {
    let currentOperation = input[i];
    number = operations[currentOperation](number);
    console.log(number);
}
}

console.log(solve(['32', 'chop', 'chop', 'chop', 'chop', 'chop']));
console.log(solve(['9', 'dice', 'spice', 'chop', 'bake', 'fillet']));