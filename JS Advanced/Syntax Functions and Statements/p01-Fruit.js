"use strict";

function solve(fruit, grams, price) {
    let weightInKg = grams / 1000;
    let money = price * weightInKg;

    return console.log(`I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}

solve('orange', 2500, 1.80);
solve('apple', 1563, 2.35);