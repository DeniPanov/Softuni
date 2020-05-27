"use strict";

function solve(input) {

    const operations = {
        counter: 1,
        add: (arr, x) => [...arr, x],
        remove: (arr) => arr.slice(0, arr.length - 1),
    }

    let result = input.reduce((acc, curr) => {
        acc = operations[curr](acc, operations.counter);
        operations.counter++;
        return acc;
    }, []);

   return result.length > 0 ? result.join("\n") : "Empty";
}

console.log(solve(['add', 'add', 'add', 'add']));
console.log(solve(['add', 'add', 'remove', 'add', 'add']));
console.log(solve(['remove', 'remove', 'remove']));