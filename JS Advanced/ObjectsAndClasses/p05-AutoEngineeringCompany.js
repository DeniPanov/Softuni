"use strict"

function solve(input) {
    let cars = {};
    for (const item of input) {
        let [make, model, count] = item.split(" | ");
        count = Number(count);

        if (cars.hasOwnProperty(make) === false) {
            cars[make] = {}
        }

        if (cars[make].hasOwnProperty(model) === false) {
            cars[make][model] = 0
        }

        cars[make][model] += count;
    }

    for (const key of Object.keys(cars)) {

        console.log(key);
        let modelKeys = Object.keys(cars[key])

        for (const model of modelKeys) {
            console.log(`###${model} -> ${cars[key][model]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']);