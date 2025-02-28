export class Car {
  constructor(name, model, speed) {
    this.name = name;
    this.model = model;
    this.totalSpeed = speed;
  }

  turn() {
    this.totalSpeed -= 5;
    this.totalSpeed = this.totalSpeed < 0 ? 0 : this.totalSpeed;
  }

  accelerate(){
    this.totalSpeed+=10;
  }

  display(){
    return `${this.name} ${this.model} | Current Speed: ${this.totalSpeed}km/h`;
  }
}
