function solve() {
    const taskTitle = document.querySelector("#task");
    const taskDescription = document.querySelector("#description");
    const taskDate = document.querySelector("#date");

    const sections = document.querySelectorAll("section");
    const openDiv = sections.item(1).querySelectorAll("div").item(1);
    const inProgressDiv = sections.item(2).querySelectorAll("div").item(1);
    const completeDiv = sections.item(3).querySelectorAll("div").item(1);

    document.querySelector("#add").addEventListener("click", addTask);

    function addTask(e) {
        e.preventDefault();

        let currentTitle = taskTitle.value.trim();
        let currentDescription = taskDescription.value.trim();
        let currentDate = taskDate.value.trim();

        let startBtn = el("button", "Start", { className: "green" });
        let deleteBtn = el("button", "Delete", { className: "red" });
        let finishBtn = el("button", "Finish", { className: "orange" });
        let buttons = el("div", [startBtn, deleteBtn], { className: "flex" });

        if (currentTitle.length > 0 && currentDescription.length > 0 && currentDate.length > 0) {
            let task = el("article", [
                el("h3", currentTitle),
                el("p", `Description: ${currentDescription}`),
                el("p", `Due Date: ${currentDate}`),
                buttons
            ]);

            openDiv.appendChild(task);

            startBtn.addEventListener("click", () => {
                inProgressDiv.appendChild(task);
                startBtn.remove();
                buttons.appendChild(finishBtn);
            });

            deleteBtn.addEventListener("click", () => {
                task.remove();
            });

            finishBtn.addEventListener("click", () => {
                completeDiv.appendChild(task);
                buttons.remove();
            });
        }
    }

    function el(type, content, attributes) {
        const result = document.createElement(type);

        if (attributes !== undefined) {
            Object.assign(result, attributes);
        }

        if (Array.isArray(content)) {
            content.forEach(append)
        } else {
            append(content);
        }

        function append(node) {
            if (typeof node === "string" || typeof node === "number") {
                node = document.createTextNode(node);
            }
            result.appendChild(node);
        }

        return result;
    }
}