using ISBN;
using System;

//Book book = new Book("", 1111); // throws exception

Book book1 = new Book("Lord of the rings", 1111);
Book book2 = new Book("asd", 1123);


Console.WriteLine(book1.AddAuthor("d"));
Console.WriteLine(book1.AddAuthor("d"));

string asd = "123-add";


Console.WriteLine(asd.FormatForIsbn());

Catalog catalog = new Catalog();

Console.WriteLine(catalog.AddIsbn("123-1-23-123321-1", book1)); // returns added successfuly

Console.WriteLine(catalog.FindBook("123-1-23-123321-1").Date); // returns 1111

//Console.WriteLine(catalog.AddIsbn("1231-23-123321-1", book1)); // returns exception

Console.WriteLine(catalog.FindBook("1231231233211").Date); // returns 1111
