export class Library {
  books: Book[] = [];

  addBook(book: Book) {
    this.books.push(book);
  }
  findBookByTitle(title:string):Book{
    return this.books.find((b)=>b.title==title);
  }

  removeBook(title:string){
    this.books.splice(this.books.findIndex((b)=>b.title==title),1);
  }

  listAvailableBooks() : Book[]{
    let books: Book[] = [];

    this.books.forEach(b=>{
        if(b.isAvailable)
            books.push(b);
    })
    return books;
  }

  getBooksbyAuthor(authorName:string):Book[]{
    let books: Book[] = [];
    
    this.books.forEach(b=>{
        if(b.author.name == authorName)
            books.push(b);
    })
    return books;
  }
}
