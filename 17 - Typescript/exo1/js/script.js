import { Library } from "./library.js";
import { createBook, toggleAvailability } from "./book.js";
let library = new Library();
let orwell = {
    name: "George Orwell",
    birthYear: 1903,
    genres: ["Dystopia", "Satire"]
};
let glukhovsky = {
    name: "Dmitry Glukhovsky",
    birthYear: 1979,
    genres: ["Dystopia", "Science Fiction"]
};
let sarkozy = {
    name: "Nicolas Sarkozy",
    birthYear: 1955,
    genres: ["Comedy, Fiction"]
};
let tempete = createBook("Le Temps des Tempêtes", sarkozy, 522);
//#region TEST
console.log(`TEST createBook
    \nShould return (le temps des tempêtes):
    \n${JSON.stringify(tempete)}`);
library.addBook(tempete);
library.addBook(createBook("1984", orwell, 376));
library.addBook(createBook("Animal Farm", orwell, 92));
library.addBook(createBook("Metro 2033", glukhovsky, 92));
console.log(`TEST createBook
    \nShould return (all the library content):
    \n${JSON.stringify(library)}`);
let animalFarm = library.findBookByTitle("Animal Farm");
console.log(`TEST findBookByTitle
    \nShould return (Animal Farm):
    \n${JSON.stringify(animalFarm)}`);
toggleAvailability(animalFarm);
console.log(`TEST availability
    \n Should return (false): ${animalFarm.isAvailable}`);
let orwellBooks = library.getBooksbyAuthor(orwell.name);
console.log(`TEST getBooksbyAuthor
    \nShould return (1984 & Animal Farm):
    \n${JSON.stringify(orwellBooks)}`);
let availableBooks = library.listAvailableBooks();
console.log(`TEST listAvailableBooks
    \nShould return (Temps des tempêtes, 1984 & Metro 2033):
    \n${JSON.stringify(availableBooks)}`);
library.removeBook("Le Temps des Tempêtes");
console.log(`TEST createBook
    \nShould return (all the library content without that funny Sarkozy book):
    \n${JSON.stringify(library)}`);
//#endregion
