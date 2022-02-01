using ISBN;
using System;

//Book book = new Book("", 1111); // throws exception

Book book1 = new Book("Lord of the rings", 1111);


Console.WriteLine(book1.AddAuthor("d"));
Console.WriteLine(book1.AddAuthor("d"));

string asd = "123-add";


Console.WriteLine(asd.FormatForIsbn());

Catalog catalog = new Catalog();

Console.WriteLine(catalog.AddIsbn("123-333", book1)); // returns added successfuly

Console.WriteLine(catalog.findBook("123-333").Date); // returns 1111

Console.WriteLine(catalog.findBook("123----33-3---").Date); // returns 1111