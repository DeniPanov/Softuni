function solve(arr, sortType) {
    function sortAsc() { arr.sort((a, b) => a - b) };
    function sortDesc() { arr.sort((a, b) => b - a) };

    sortType.toLowerCase() === "asc" ? sortAsc() : sortDesc();

    return arr;
}