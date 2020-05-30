"use strict"

function solve(input) {

    function createTag(tag, content) {
        return `<${tag}>${content}</${tag}>\n`;
    }

    let result = "<table>\n";

    for (const element of input) {

        let currentElement = JSON.parse(element)

        result += "\t<tr>\n";
        result += "\t\t" + createTag("td", currentElement.name);
        result += "\t\t" + createTag("td", currentElement.position);
        result += "\t\t" + createTag("td", currentElement.salary);
        result += "\t</tr>\n";
    }

    return result + "</table>";
}

console.log(solve(['{"name":"Pesho","position":"Promenliva","salary":100000}',
'{"name":"Teo","position":"Lecturer","salary":1000}',
'{"name":"Georgi","position":"Lecturer","salary":1000}']
));