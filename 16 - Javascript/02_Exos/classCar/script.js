import { Car } from "./classes/car.js";

let car1 = new Car("BMW", "Serie1", 80);
let car2 = new Car("Merco", "GLB", 100);

for (let i = 0; i < 3; i++) car1.accelerate();
for (let i = 0; i < 2; i++) car2.accelerate();
for (let i = 0; i < 2; i++) car2.turn();

console.log(car1.display());
console.log(car2.display());
