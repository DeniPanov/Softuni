function toggle() {
    let text = document.querySelector("#extra");
    let btn = document.querySelectorAll(".button")[0];
    
    if (text.style.display === "none") {
        text.style.display = "block";
        btn.textContent = "Less";
    } else {
        text.style.display = "none"
        btn.textContent = "More";
    }
}