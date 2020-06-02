"use strict"

function solve(input) {
    function sortByTwoCriteria(arr){
            return arr.sort((a, b) => a.length - b.length ||
                a.localeCompare(b));
        }

    let db = {};
    
    for (const item of input) {
        let[system, component, sub] = item.split(" | ");

        if (db.hasOwnProperty(system) === false) {
            db[system] = {};
        }

        if (db[system].hasOwnProperty(component) === false) {
            db[system][component] = [];
        }

        db[system][component].push(sub);
    }

    console.log(db);
}

console.log(solve(['SULS | Main Site | Home Page',
'SULS | Main Site | Login Page',
'SULS | Main Site | Register Page',
'SULS | Judge Site | Login Page',
'SULS | Judge Site | Submittion Page',
'Lambda | CoreA | A23',
'SULS | Digital Site | Login Page',
'Lambda | CoreB | B24',
'Lambda | CoreA | A24',
'Lambda | CoreA | A25',
'Lambda | CoreC | C4',
'Indice | Session | Default Storage',
'Indice | Session | Default Security']));