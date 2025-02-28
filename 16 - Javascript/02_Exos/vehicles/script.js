import { Car } from "./classes/car.js";
import { Moto } from "./classes/moto.js";

let output = document.querySelector(".out");

let car = new Car("Renault", "Kangoo","240.000",2003, "AC");
let moto = new Moto("BMW", "R1150R Rockster","65.000",2005);

output.innerHTML = `${car.display()}\n${moto.display()}`;