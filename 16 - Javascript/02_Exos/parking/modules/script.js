import {Vehicle} from "./vehicle.js"


let parking = [
    new Vehicle("BMW","33333",Date(2025,2,28,14,50)), // 14h50
    new Vehicle("Citroen","22222",Date(2025,2,28,14,35)), // 14h35
    new Vehicle("BMW","33333",Date(2025,2,28,14,20)), // 14h20
    new Vehicle("Renault","11111",new Date(2025,2,28,14)), //14h
];

const currentTime = new Date(2025,2,28,15); // 15h
const input = document.querySelector(".matricleInput");
const output = document.querySelector(".output");
const payButton = document.querySelector(".payButton");
document.querySelector(".ticketButton").addEventListener("click",getPrice);

window.onload = setup();
function setup(){
    payButton.style.visibility = 'hidden';
}

function getPrice(){
    payButton.style.visibility = 'hidden';
    let vehicle = parking.find(v=> v.register == input);
    if(vehicle == undefined){
        output.innerHTML = "Ce véhicule n'est pas dans le parking !";
    }
    else{
        let minutes = (currentTime-vehicle.enterDate)*60;
        if(minutes<0){
            output.innerHTML = `<p class="error">ERREUR! Vous êtes dans le futur</p>`
        }else
        if(minutes<=15){
            output.innerHTML = `<p class="warning">Vous devez payer 1.30€</p>`
        }else if(minutes<=30){
        }else if(minutes<=45){
            output.innerHTML = `<p class="warning">Vous devez payer 1.70€</p>`            
        }else{
            output.innerHTML = `<p class="warning">Vous devez payer 6.00€</p>`
        }
        payButton.style.visibility = 'initial';
    }
}

