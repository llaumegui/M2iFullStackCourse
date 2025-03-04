import { Item, CartItem } from "./modules/item.js";

const itemList = document.querySelector(".itemList");
document.querySelector(".cart").addEventListener("click", toggleSlide);
document.getElementById("clearBtn").addEventListener("click", clearCart);
const cartContainer = document.getElementById("cart-container");
let cart = [];
let openCart = false;

//#region FAKESHOP
let shop = [
  new Item("THE SUBSTANCE TEE", 38.95, [
    "https://ayylienclothing.com/cdn/shop/files/Ayylien-TheSubstance-AVL1605_Tee-OilGreen-FrontWEBREADY-796f3ba8-6e32-4102-8784-c7d239887742_720x.png",
    "https://ayylienclothing.com/cdn/shop/files/Ayylien-TheSubstance-AVL1605_Tee-OilGreen-BackWEBREADY-7fb965bd-47ca-406e-89b1-69e2afcdcc5c_720x.png",
  ]),
  new Item("EVERYTHING RETURNS TO NOTHING", 29.95, [
    "https://ayylienclothing.com/cdn/shop/products/Ayylien-EverythingReturnsToNothing-Tee-White-Front_720x.png",
    "https://ayylienclothing.com/cdn/shop/products/Ayylien-EverythingReturnsToNothing-Tee-White-Back_720x.png",
  ]),
  new Item("COSMIC HORROR", 62.95, [
    "https://ayylienclothing.com/cdn/shop/files/Ayylien-CosmicHorror-CosmicHorrors-AVL1400BlackHoodie-Front_720x.png",
    "https://ayylienclothing.com/cdn/shop/files/Ayylien-CosmicHorror-CosmicHorrors-AVL1400BlackHoodie-back_720x.png",
  ]),
  new Item("PSYCHEDELIC EXPLORE YOUR MIND", 62.95, [
    "https://ayylienclothing.com/cdn/shop/files/Ayylien-CosmicHorror-ExploreYourMind-AVL1404-VintageCloudPurpleHoodie-Front_720x.png",
    "https://ayylienclothing.com/cdn/shop/files/Ayylien-CosmicHorror-ExploreYourMind-AVL1404-VintageCloudPurpleHoodie-Back_720x.png",
  ]),
];
//#endregion

function toggleSlide() {
  if (openCart) $.slideUp();
  else $.slideDown();
  openCart = !openCart;
}

$.slideUp = function () {
  $("#cart-container").slideUp();
};
$.slideDown = function () {
  $("#cart-container").slideDown();
};

function loadItems() {
  itemList.innerHTML = "";
  shop.forEach((item) => {
    let container = document.createElement("div");
    container.classList.add("itemContainer");
    let picture = document.createElement("img");
    picture.classList.add("itemImage");
    picture.setAttribute("src", item.image[0]);
    picture.setAttribute("onmouseover", `this.src="${item.image[1]}"`);
    picture.setAttribute("onmouseout", `this.src="${item.image[0]}"`);

    container.appendChild(picture);

    let containerInfo = document.createElement("div");
    containerInfo.classList.add("infoContainer");
    let containerTxt = document.createElement("div");

    let name = document.createElement("p");
    name.classList.add("itemName");
    name.innerHTML = item.name;
    let price = document.createElement("p");
    price.classList.add("itemPrice");
    price.innerHTML = `${item.price}€`;

    containerTxt.appendChild(name);
    containerTxt.appendChild(price);

    let btn = document.createElement("button");
    btn.innerHTML = "ADD";
    btn.classList.add("addCartBtn");
    btn.addEventListener("click", addToCart);
    btn.param = item;

    containerInfo.appendChild(btn);

    containerInfo.appendChild(containerTxt);
    container.appendChild(containerInfo);
    itemList.appendChild(container);
  });
}

function addToCart(event) {
  let item = event.currentTarget.param;

  let i = cart.find((c) => c.item == item);
  if (i != undefined) i.quantity += 1;
  else cart.push(new CartItem(item));

  updateCart();
  saveCart();
}

function updateCart() {
  if (cart.length < 1) return;

  cartContainer.innerHTML = "";

  cart.forEach((e) => {
    let item = e.item;
    let hr = document.createElement("hr");
    cartContainer.appendChild(hr);
    let container = document.createElement("div");
    container.classList.add("itemContainerCart");
    let picture = document.createElement("img");
    picture.classList.add("itemImageart");
    picture.setAttribute("src", item.image[0]);

    container.appendChild(picture);

    let containerInfo = document.createElement("div");
    containerInfo.classList.add("infoContainerCart");
    let containerTxt = document.createElement("div");

    let name = document.createElement("p");
    name.classList.add("itemNameCart");
    name.innerHTML = item.name;
    let price = document.createElement("p");
    price.classList.add("itemPriceCart");
    price.innerHTML = `${item.price}€`;
    let quantity = document.createElement("p");
    price.classList.add("itemQuantityCart");
    price.innerHTML = `quantity: ${e.quantity}`;
    containerTxt.appendChild(name);
    containerTxt.appendChild(price);
    containerTxt.appendChild(quantity);

    containerInfo.appendChild(containerTxt);
    container.appendChild(containerInfo);
    cartContainer.appendChild(container);
  });
}

function clearCart() {
  cart = [];
  updateCart();
  saveCart();
}

function saveCart() {
  localStorage.setItem("cart", JSON.stringify(cart));
}

window.onload = () => {
  loadItems();
  cart = JSON.parse(localStorage.getItem("cart"));
  if (cart == null) cart = [];
  console.log(cart);

  updateCart();
};
