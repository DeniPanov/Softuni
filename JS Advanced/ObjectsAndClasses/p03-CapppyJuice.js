"use strict"

function solve(input) {
    let juices = {};

    for (const item of input) {
        let [fruit, quantity] = item.split(" => ");
        quantity = Number(quantity);

        juices.hasOwnProperty(fruit) === false
            ? juices[fruit] = quantity
            : juices[fruit] += quantity
    }

    let result = {};
    // See the output requirements!

    let keys = Object.keys(juices);

    for (const key of keys) {
        if (juices[key] >= 1000) {
            result[key] = Math.floor(juices[key] / 1000)
        }
    }

    for (let [key, value] of Object.entries(result)) {
        if (value !== 0) {
            console.log(`${key} => ${value}`);
        }
    }
}

solve(['Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549']);

solve(['Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789']);