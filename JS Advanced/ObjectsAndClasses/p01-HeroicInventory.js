"use strict"

function solve(input){
    let result = [];

    for (const element of input) {
        let [name, level, items] = element.split(" / ");
        level = Number(level);
        items = items ? items.split(", ") : [];

        result.push({name, level, items})
    }

    return JSON.stringify(result);
}

console.log(solve(['Isacc / 25 / Apple, GravityGun',
'Derek / 12 / BarrelVest, DestructionSword',
'Hes / 1 / Desolator, Sentinel, Antara']
));

console.log(solve(['Jake / 1000 / Gauss, HolidayGrenade']));