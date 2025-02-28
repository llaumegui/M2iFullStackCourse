export class Vehicle {
  constructor(name, register, enterDate, exitDate) {
    this.name = name;
    this.register = register
    this.enterDate = enterDate;
  }

  display() {
    return `${this.name} - ${this.model} - enter: ${this.enterDate}`;
  }
}
