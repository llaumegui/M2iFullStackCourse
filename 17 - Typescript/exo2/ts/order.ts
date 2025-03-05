import { Status } from "./enums.js";
import { Customer, OrderItem, Order } from "./interfaces.js";
import { OrderManager } from "./orderManager.js";

export function createOrder(customer: Customer, items: OrderItem[]): Order {
  let order: Order = {
    id: OrderManager.setOrderId(),
    customer: customer,
    items: items,
    status: Status.Pending,
  };

  return order;
}

export function calculateTotal(order): number {
  let total = 0;
  order.items.forEach((i) => {
    total += (i.product.price * i.quantity);
  });
  return total;
}

export function toString(order:Order):string{
    return  `[id:${order.id}, customer:${order.customer.name},status:${Status[order.status]}]`;
  }