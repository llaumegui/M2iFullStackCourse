let nbrToFind = 0;
let tries = 0;
let end = false;
let message = document.getElementById("outputText");
let tryText = document.getElementById("tryText");
let nbr = document.querySelector(".inputNbr");

window.onload = setup();


document.addEventListener("keydown", (event) => {
    if (event.key == "Enter"){
        alert("keydown");
        tryNumber();
    }
})


function setup() {
  tries = 0;
  nbrToFind = Math.round(Math.random() * 50 + 1);
  end = false;
  message.textContent = "";
  tryText.textContent = `Nombre d'essais: ${tries}`;

  document.getElementById("replay").style.visibility = "hidden";
}


function tryNumber(){
    let test = nbr.value;
    if(end || test <1 || test >50)
        return;

    if(test==nbrToFind){
        end = true;
        message.textContent = `Bravo! vous avez gagné en ${tries} essais!`;
    }else{
        tries++;
        
        if(test<nbrToFind)
            message.textContent = "Plus grand!"
        else
        message.textContent = "Plus petit!"
    tryText.textContent = `nombre d'essais: ${tries}`;
}

if(end)
        document.getElementById("replay").style.visibility = "initial";
}
