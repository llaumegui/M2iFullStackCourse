import { Status } from "./enums.js";
import { OrderManager } from "./orderManager.js";
export function createOrder(customer, items) {
    let order = {
        id: OrderManager.setOrderId(),
        customer: customer,
        items: items,
        status: Status.Pending,
    };
    return order;
}
export function calculateTotal(order) {
    let total = 0;
    order.items.forEach((i) => {
        total += (i.product.price * i.quantity);
    });
    return total;
}
export function toString(order) {
    return `[id:${order.id}, customer:${order.customer.name},status:${Status[order.status]}]`;
}
