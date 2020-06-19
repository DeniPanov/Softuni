function solve(...args) {
    let result = {};

    args.forEach(arg => {
        let type = typeof arg;
        console.log(`${type}: ${arg}`);

        result[type] > 0 ? result[type] += 1 : result[type] = 1;

        result = Object.fromEntries(Object.entries(result)
            .sort((a, b) => b[1] - a[1]))
    });
    Object.keys(result).forEach(e => console.log(`${e} = ${result[e]}`));
}