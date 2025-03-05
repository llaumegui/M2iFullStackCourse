import { Status } from "./enums.js";
import { Customer, Product, OrderItem } from "./interfaces.js";
import { createOrder, calculateTotal, toString } from "./order.js";
import { OrderManager } from "./orderManager.js";

let orderManager = new OrderManager();

//#region SETUP
let theoH: Customer = {
  name: "Théo Henno",
  email: "pipi@caca.fr",
};

let tomato: Product = {
  name: "Tomato",
  price: 0.85,
  stock: 50,
};
let potato: Product = {
  name: "Potato",
  price: 0.5,
  stock: 100,
};
let potatoes: OrderItem = {
  product: potato,
  quantity: 10,
};
let tomatoes: OrderItem = {
  product: tomato,
  quantity: 5,
};

//#endregion
let order = createOrder(theoH, [tomatoes, tomatoes]);

orderManager.addOrder(order);
orderManager.addOrder(createOrder(theoH, [tomatoes, potatoes]));
orderManager.addOrder(createOrder(theoH, [potatoes, potatoes]));
console.log(`test create order and add order:
    \n${orderManager.toString()}`);

console.log(`test getTotalPrice from order1
    \n${calculateTotal(order)}€`);

let secondOrder = orderManager.getOrderById(2);
console.log(`tset get order by id 2:
    \n${toString(secondOrder)}`);

// update first order
orderManager.updateOrderStatus(1, Status.Shipped);
console.log(`test update status:
    \n${toString(orderManager.getOrderById(1))}`);

console.log(`test list orders by status:
    \n${orderManager.toString(
      orderManager.listOrdersByStatus(Status.Pending)
    )}`);

orderManager.removeOrder(2);
console.log(`test orders after removing:
    \n${orderManager.toString()}`);
