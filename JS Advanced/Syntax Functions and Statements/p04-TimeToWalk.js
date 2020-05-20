"use strict";

function solve(steps, meters, speed ){
    speed /= 60;
    let distance = steps * meters / 1000;
    let rest = Math.floor(distance / 0.500);
    let time = ((distance / speed) + rest);

    let minutes = Math.floor(time);
    let hours = Math.floor(minutes / 60);
    let seconds = Math.round((time - minutes) * 60);

    console.log((hours < 10 ? "0" : "") + hours + 
         ":" + (minutes < 10 ? "0" : "") + (minutes) +
         ":" + (seconds < 10 ? "0" : "") + seconds);
}

solve(4000, 0.60, 5);