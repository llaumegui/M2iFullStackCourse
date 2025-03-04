const apiUrl = "https://pokeapi.co/api/v2";

const input = document.querySelector(".input");
const output = document.querySelector(".output");
let data;

async function maxNumber() {
    try { 
        let response = await fetch(`${apiUrl}/pokemon-species`);
        let val = await response.json();
        return val.count;
    } catch (error) {
        console.error(error);
        throw(error);
    }
    return undefined;
}

async function getPkmn(value = input.value) {
    try { 
        let response = await fetch(`${apiUrl}/pokemon/${value}`);
        data = await response.json()
    } catch (error) {
        console.error(error);
        throw(error);
    }
    display();
}

async function nextPkmn(val){
    let max = await maxNumber();
    console.log(max);

    let nbr = data.id + val;
    nbr = nbr<1 ? max : nbr;
    nbr = nbr>max ? 1: nbr;
    getPkmn(nbr)
}

function display(){
    output.innerHTML = "";
    output.innerHTML += `<h3>${data.name} | #${data.id}</h3>`;
    output.innerHTML += `<img src="${data.sprites.front_default}"/>`;
}

window.onload = getPkmn(1);