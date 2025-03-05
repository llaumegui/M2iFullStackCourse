import { Status } from "./enums.js";
import { Order } from "./interfaces.js";
import { toString } from "./order.js";

export class OrderManager {
  orders: Order[] = [];

  static orderId: number = 1;

  static setOrderId(): number {
    this.orderId += 1;
    return this.orderId - 1;
  }

  addOrder(order: Order) {
    this.orders.push(order);
  }

  getOrderById(id: number): Order | undefined {
    return this.orders.find((o) => o.id == id);
  }

  updateOrderStatus(id: number, status: Status) {
    let order = this.getOrderById(id);
    if (order != undefined) order.status = status;
  }

  listOrdersByStatus(status: Status): Order[] {
    let orders: Order[] = [];

    orders = this.orders.filter((o) => o.status == status);
    return orders;
  }

  removeOrder(id: number) {
    this.orders.splice(
      this.orders.findIndex((o) => o.id == id),
      1
    );
  }

  toString(orders:Order[] = this.orders): string {
    let val: string = "";
    orders.forEach((o) => (val += toString(o)));
    return `orders:${orders.length} | ${val}`;
  }
}
