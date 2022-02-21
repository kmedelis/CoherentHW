using System;
namespace ISBN
{
	public class Catalog
	{
		private Dictionary<string, string> _keys;
		private Dictionary<string, Book> _catalogOfBooks;

		public Catalog()
		{
			_catalogOfBooks = new Dictionary<string, Book>();
		}

		public string AddIsbn(string key, Book value)
        {
			if (key.FormatForIsbn() == null)
            {
				throw new ArgumentException();
			}				
			_catalogOfBooks.Add(key.FormatForIsbn(), value);
			return "ISBN added successfully";
        }

		public Book FindBook(string key)
        {
			if (key.FormatForIsbn() == null)
			{
				throw new ArgumentException();
			}
			Book bookToReturn = _catalogOfBooks[key.FormatForIsbn()];
			return bookToReturn;
        }

	}
}

