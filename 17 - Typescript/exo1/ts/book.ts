export function createBook(title:string,author:Author,pages:number) : Book  {    
    let book : Book = {
        title: title,
        author: author,
        pages: pages,
        isAvailable: true
    };
    return book;
}

export function toggleAvailability(book:Book){
    book.isAvailable = !book.isAvailable;
}