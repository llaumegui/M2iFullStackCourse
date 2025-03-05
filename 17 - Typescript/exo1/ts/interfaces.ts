interface Author{
    name:string;
    birthYear:number;
    genres:string[];
}

interface Book{
    title:string;
    author:Author;
    pages:number;
    isAvailable:boolean;
}