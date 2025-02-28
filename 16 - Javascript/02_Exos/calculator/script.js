let text = document.getElementById("screenText");
text.textContent = "0";
let calcDone = false;
let val = 0;

// ... => spread operator = copie d'un tableau
const touches = [...document.querySelectorAll(".buttons")];

document.addEventListener("keydown", (event) => {
  checkKey(event.key);
});

touches.forEach((button) => {
  button.addEventListener("click", (e) => {
    let element = e.target;
    checkKey(element.innerText);
  });
});

function calc() {
  if (calcDone) return;

  val = eval(text.textContent);
  if (val == undefined) {
    val = 0;
    return;
  }
  calcDone = true;

  text.textContent += `\n=\n ${val}`;
}
function checkKey(key) {
  if (key == "Enter" || key == "=") {
    calc();
  }
  if (key == "c" || key == "C") {
    text.textContent = "";
    calcDone = false;
  }
  if (key == "Backspace") {
    if (calcDone) return;
    text.textContent = text.textContent.substring(
      0,
      text.textContent.length - 1
    );
  }
  if ("0123456789().".includes(key)) {
    if (calcDone) return;
    if (text.textContent[0] == 0) text.textContent = "";

    text.textContent += key;
}
if ("/*-+".includes(key)) {
    if (text.textContent[0] == 0) return;
    if (calcDone) {
        calcDone = false;
        text.textContent = val;
    }
    text.textContent += key;
  }
}
