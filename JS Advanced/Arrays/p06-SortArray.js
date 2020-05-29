"use strict"

function solve(arr) {
    return arr.sort((a, b) => a.length - b.length ||
        a.toLowerCase().localeCompare(b.toLowerCase())).join("\n");
}

console.log(solve(['test', 
'Deny', 
'omen', 
'Default']
));