export class Item {
    constructor(name, price, img = []){
        this.name = name;
        this.price = price;
        this.image = img;
    }
}

export class CartItem{
    constructor(item){
        this.item = item;
        this.quantity = 1;
    }
}