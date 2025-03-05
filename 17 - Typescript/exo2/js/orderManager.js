import { toString } from "./order.js";
export class OrderManager {
    constructor() {
        this.orders = [];
    }
    static setOrderId() {
        this.orderId += 1;
        return this.orderId - 1;
    }
    addOrder(order) {
        this.orders.push(order);
    }
    getOrderById(id) {
        return this.orders.find((o) => o.id == id);
    }
    updateOrderStatus(id, status) {
        let order = this.getOrderById(id);
        if (order != undefined)
            order.status = status;
    }
    listOrdersByStatus(status) {
        let orders = [];
        orders = this.orders.filter((o) => o.status == status);
        return orders;
    }
    removeOrder(id) {
        this.orders.splice(this.orders.findIndex((o) => o.id == id), 1);
    }
    toString(orders = this.orders) {
        let val = "";
        orders.forEach((o) => (val += toString(o)));
        return `orders:${orders.length} | ${val}`;
    }
}
OrderManager.orderId = 1;
