"use strict"

function solve(input){
    let products = {};
    for (const item of input) {

        let [name, price] = item.split(" : ");
        const firstLetter = name[0];
        price = Number(price);

        if (products.hasOwnProperty(firstLetter) === false) {
            products[firstLetter] = {};
        }

        products[firstLetter][name] = price;
    }

    const keys = Object.keys(products).sort((a, b) => a.localeCompare(b));

    for (const key of keys) {

        console.log(key);
        let sortedProducts = Object.keys(products[key]).sort((a, b) => a.localeCompare(b));

        for (const product of sortedProducts) {
            console.log(`  ${product}: ${products[key][product]}`);
        }
    }
}

solve(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']);

solve(['Banana : 2',
"Rubic's Cube : 5",
'Raspberry P : 4999',
'Rolex : 100000',
'Rollon : 10',
'Rali Car : 2000000',
'Pesho : 0.000001',
'Barrel : 10']);