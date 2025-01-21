let numberToGuess = 0;

const NEUTRAL = 0;
const HAPPY = 1;
const SERIOUS = 2;

const waitForNextLoop = async () => new Promise((resolve) => {
    setTimeout(() => {
        resolve();
    }, 500);

    return true;
});

function init() {
  let guessCount = 0,
    testGuess = 0;
  numberToGuess = Math.random() * 1000;
  updateLagaf(NEUTRAL);

  do {
    testGuess = prompt("Choisissez un Nombre");
    if (testGuess == null) return;

    guessCount++;
    if (testGuess < numberToGuess) {
      //console.log("C'est Moins!");
      updateLagaf(SERIOUS);
    }
    if (testGuess > numberToGuess) {
      //console.log("C'est Plus!");
      updateLagaf(SERIOUS);
    }

  } while (testGuess != numberToGuess);

  updateLagaf(HAPPY);
  changeReplay();
}

updateLagaf(NEUTRAL);

//#region JS for HTML
function updateLagaf(emotion) {
    console.log("lagafouille")
  for (let i = 0; i <= 2; i++) {
    let x = document.getElementById(i);
    if (i == emotion) x.style.display = "block";
    else x.style.display = "none";
  }
}

function changeReplay() {
  document.getElementById("p1").innerHTML = "Rejouer";
}
//#endregion
