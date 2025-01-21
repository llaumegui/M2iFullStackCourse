let inventory = [
  { name: "Boules de Noël", quantity: 50, price: 1.5 },
  { name: "Guirlandes", quantity: 50, price: 3.0 },
  { name: "Sapin de Noël", quantity: 10, price: 25.0 },
];

function show_inventory() {
  for (let i = 0; i < inventory.length; i++) show_item(inventory[i]);
}

function show_item(product) {
  console.log(
    `${product.name} | quantité: ${product.quantity}, prix: ${product.price}`
  );
}

function add_item() {
  let name = prompt_name();
  let quantity = prompt_quantity();
  let price = prompt_price();

  let product = inventory.find((e) => e.name == name);
  if (product != null) {
    modifier_quantite(product.name, product.quantity + quantity);
  } else {
    inventory.push({ name: name, quantity: quantity, price: price });
  }
}

function prompt_name() {
  return prompt("insérer le nom du produit: ");
}
function prompt_quantity() {
  return prompt("insérer la quantité du produit: ");
}
function prompt_price() {
  return prompt("insérer le prix du produit: ");
}

function alert_notFound(){
    return alert(`l'article demandé n'existe pas !!!`)
}

function delete_item() {
  let name = prompt_name();
  let product = inventory.find((e) => e.name == name);
  if (product == null) return alert_notFound();
  else inventory.splice(inventory.indexOf(product), 1);
}

function change_quantity() {
  let name = prompt_name();
  let quantity = prompt_quantity();
  let product = inventory.find((e) => e.name == name);
  if (product != null) {
    product.quantity =
      product.quantity - quantity < 0 ? 0 : product.quantity - quantity;
  } else {
    return alert_notFound();
  }
}

function search_item() {
  let name = prompt_name();
  let product = inventory.find((e) => e.name == name);
  if (product != null) {
    show_item(product);
  } else {
    return alert_notFound();
  }
}

function total_value() {
  let total = 0;
  for (let i = 0; i < inventory.length; i++)
    total += inventory[i].quantity * inventory[i].price;
}

function menu() {
  let input = 0;
  do {
    input = Number(
      prompt(`
        1.Afficher inventaire\n
        2.Ajouter produit\n
        3.Supprimer produit\n
        4.Modifier quantité\n
        5.Rechercher produit\n
        6.Valeur totale\n
        7.Quitter`)
    );

    switch (input) {
      case 1:
        show_inventory();
        break;
      case 2:
        add_item();
        break;
      case 3:
        delete_item();
        break;
      case 4:
        change_quantity();
        break;
      case 5:
        search_item();
        break;
      case 6:
        total_value();
        break;
      default:
        return;
    }
  } while (input > 0 || input <= 6);
}

menu();
