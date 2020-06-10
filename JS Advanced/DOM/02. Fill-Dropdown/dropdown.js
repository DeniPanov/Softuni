function addItem() {
    let text = document.querySelector("#newItemText");
    let value = document.querySelector("#newItemValue");
    const option = document.createElement("option");

    option.textContent = text.value;
    option.value = value.value;
    document.querySelector("#menu").appendChild(option);

    text.value = "";
    value.value = "";
}