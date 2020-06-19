function solve() {
    function restock(input) {
        microelement = input[0].toLowerCase();
        quantity = Number(input[1]);
        microelements[microelement] += Number(quantity);
        return "Success";
    }

    function prepare(input) {
        let recipe = input[0].toLowerCase();
        quantity = Number(input[1]);
        let result = "";
        if (quantity * recipes[recipe]["protein"] > microelements["protein"]) {
            result = "Error: not enough protein in stock";
        } else if (quantity * recipes[recipe]["carbohydrate"] > microelements["carbohydrate"]) {
            result = "Error: not enough carbohydrate in stock";
        } else if (quantity * recipes[recipe]["fat"] > microelements["fat"]) {
            result = "Error: not enough fat in stock";
        } else if (quantity * recipes[recipe]["flavour"] > microelements["flavour"]) {
            result = "Error: not enough flavour in stock";
        } else {
            result = "Success";
            microelements["protein"] -= quantity * recipes[recipe]["protein"];
            microelements["carbohydrate"] -= quantity * recipes[recipe]["carbohydrate"];
            microelements["fat"] -= quantity * recipes[recipe]["fat"];
            microelements["flavour"] -= quantity * recipes[recipe]["flavour"];
        }
        return result;
    }

    function report() {
        return `protein=${microelements['protein']} carbohydrate=${microelements['carbohydrate']} fat=${microelements['fat']} flavour=${microelements['flavour']}`;
    }
    let microelements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }
    let recipes = {
        apple: { protein: 0, carbohydrate: 1, flavour: 2, fat: 0 },
        lemonade: { protein: 0, carbohydrate: 10, flavour: 20, fat: 0 },
        burger: { protein: 0, carbohydrate: 5, flavour: 3, fat: 7 },
        eggs: { protein: 5, carbohydrate: 0, flavour: 1, fat: 1 },
        turkey: { protein: 10, carbohydrate: 10, flavour: 10, fat: 10 },
    }
    return function (command) {
        command = command.split(' ');
        let action = command.shift();
        switch (action) {
            case "prepare":
                return prepare(command);
                break;
            case "restock":
                return restock(command);
                break;
            case "report":
                return report();
                break;
        }
    }
}