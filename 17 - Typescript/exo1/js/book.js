export function createBook(title, author, pages) {
    let book = {
        title: title,
        author: author,
        pages: pages,
        isAvailable: true
    };
    return book;
}
export function toggleAvailability(book) {
    book.isAvailable = !book.isAvailable;
}
