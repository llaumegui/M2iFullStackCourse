export class Vehicle {
  constructor(name, model, kilometers, year) {
    this.name = name;
    this.model = model;
    this.kilometers = kilometers;
    this.year = year;
  }

  display() {
    return `${this.name} - ${this.model} - ${this.kilometers}km - ${this.year}`;
  }
}
