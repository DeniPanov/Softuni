function subtract() {
    let num1 = Number(document.querySelector("#firstNumber").value);
    let num2 = Number(document.getElementById("secondNumber").value);
    document.getElementById("result").textContent = num1 - num2;
}