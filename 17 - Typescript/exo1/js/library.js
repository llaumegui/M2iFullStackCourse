export class Library {
    constructor() {
        this.books = [];
    }
    addBook(book) {
        this.books.push(book);
    }
    findBookByTitle(title) {
        return this.books.find((b) => b.title == title);
    }
    removeBook(title) {
        this.books.splice(this.books.findIndex((b) => b.title == title), 1);
    }
    listAvailableBooks() {
        let books = [];
        this.books.forEach(b => {
            if (b.isAvailable)
                books.push(b);
        });
        return books;
    }
    getBooksbyAuthor(authorName) {
        let books = [];
        this.books.forEach(b => {
            if (b.author.name == authorName)
                books.push(b);
        });
        return books;
    }
}
