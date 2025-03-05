import { Status } from "./enums.js";

export interface Product {
  name: string;
  price: number;
  stock: number;
}

export interface Customer {
  name: string;
  email?: string;
}

export interface OrderItem {
  product: Product;
  quantity: number;
}

export interface Order {
  readonly id: number;
  customer: Customer;
  items: OrderItem[];
  status: Status;
}
