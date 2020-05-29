"use strict";

function solve(input){
    let arr = input.slice();
    let temp = Number(arr.pop());
    const step = arr.length > temp ? temp : arr.length % temp;
    rotate(arr, step);
    return arr.join(" ");

    function rotate(arr, step){
        for (let index = 0; index < step; index++) {
            const lastElement = arr.pop();
            arr.unshift(lastElement);
        }
    }
}