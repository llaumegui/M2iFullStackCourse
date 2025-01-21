let tab = [];

function typeTab() {
  let size = getInput("Insert Size");
  for (let i = 0; i < size; i++) {
    tab[i] = getInput(`Insert number for tab[${i}]`);
  }
}

function showTab() {
  let message = "";
  for (let i = 0; i < tab.length; i++) {
    message += `${tab[i]}; `;
  }
  console.log(message);
}

function showTabNumber() {
  let number = getInput(`Insert number to display`);
  if (!testNumber(number)) return errorNumber();
  return console.log(tab[number - 1]);
}

function getInput(message) {
  return Number(prompt(message));
}

function testNumber(number) {
  console.log(`size ${tab.length}`);
  if (number <= 0 || number > tab.length) return false;
  return true;
}

function errorNumber() {
  return alert("Wrong number !");
}

function classRoom() {
  let tab = [];
  for (let i = 0; i < 15; i++) {
    for (let j = 0; j < 3; j++) {
      tab[(i, j)] = Number(
        prompt(`Entrer la note de l'étudiant ${i + 1} dans la matière ${j + 1}`)
      );
      console.log(tab[(i, j)]);
    }
  }
}

// typeTab();
// showTab();
