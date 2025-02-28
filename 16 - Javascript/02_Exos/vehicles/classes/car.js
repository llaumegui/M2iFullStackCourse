import { Vehicle } from "./vehicle.js";

export class Car extends Vehicle {
  constructor(name, model, kilometers, year, particularity) {
    super(name, model, kilometers, year);
    this.particularity = particularity;
    // add wheels etc
  }

  display() {
    return `Auto - ${super.display()} - ${this.particularity}`;
  }
}
