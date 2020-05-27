"use strict";

function solve(arr){
    let myArr = arr.slice();
    return (myArr.join(myArr.pop()));
}

console.log(solve(['One', 'Two', 'Three', 'Four', 'Five', '-']));
console.log(solve(['How about no?', 'I','will', 'not', 'do', 'it!', '_']));