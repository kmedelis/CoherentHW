using System;
namespace ISBN
{
	public class Catalog
	{
		public Dictionary<string, string> Keys;
		public Dictionary<string, Book> CatalogOfBooks;

		public Catalog()
		{
			CatalogOfBooks = new Dictionary<string, Book>();
		}

		public string AddIsbn(string key, Book value)
        {
			CatalogOfBooks.Add(key.FormatForIsbn(), value);
			return "ISBN added successfully";
        }

		public Book findBook(string key)
        {
			Book bookToReturn = CatalogOfBooks[key.FormatForIsbn()];
			return bookToReturn;
        }

	}
}

