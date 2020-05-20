"use strict";

function solve(arr){
    let speedLimit = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20,
    }

    let speed = arr[0];
    let area = arr[1];

    let result;
    let currentSpeed = speed - speedLimit[area];

    if(currentSpeed <= 0){
        result = "";
    }
    else if (currentSpeed <= 20){
        result = "speeding";
    }
    else if (currentSpeed <= 40){
        result = "excessive speeding";
    } else {
        result = "reckless driving"
    }    
    return result;
}

console.log(solve([40, 'city']));
console.log(solve([21, 'residential']));
console.log(solve([120, 'interstate']));
console.log(solve([200, 'motorway']));
