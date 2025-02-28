import { Vehicle } from "./vehicle.js";

export class Moto extends Vehicle {
  constructor(name, model, kilometers, year) {
    super(name, model, kilometers, year);
    // add wheels etc
  }

  display() {
    return `Moto - ${super.display()}`; // add other particularities etc
  }
}
