function create(words) {
   const content = document.querySelector("#content");

   for (const word of words) {
      const div = document.createElement("div");
      const paragraph = document.createElement("p");

      paragraph.textContent = word;
      paragraph.style.display = "none";
      div.appendChild(paragraph);

      div.addEventListener("click", function (e) {
         paragraph.style.display = "block";
      })

      content.appendChild(div);
   }
}