function solve() {
    document.querySelector("button").addEventListener("click", onClick);

    const alphabet = {
        A: 0,
        B: 1,
        C: 2,
        D: 3,
        E: 4,
        F: 5,
        G: 6,
        H: 7,
        I: 8,
        J: 9,
        K: 10,
        L: 11,
        M: 12,
        N: 13,
        O: 14,
        P: 15,
        Q: 16,
        R: 17,
        S: 18,
        T: 19,
        U: 20,
        V: 21,
        W: 22,
        X: 23,
        Y: 24,
        Z: 25
    };

    function onClick(e) {
        let input = document.querySelector("input");
        let allLiTags = document.querySelectorAll("li");
        let name = input.value;
        let firstLetter = name[0].toUpperCase();
        let correctName = firstLetter + name.substring(1);
        let index = alphabet[firstLetter];
        let currentLiTag = allLiTags[index];

        currentLiTag.textContent === "" 
        ? currentLiTag.textContent = correctName
        : currentLiTag.textContent += `, ${correctName}`;

        input.value = "";
    }
}