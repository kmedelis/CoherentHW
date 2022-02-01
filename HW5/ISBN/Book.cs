using System;
namespace ISBN
{
	public class Book
	{
		public string Title;
		public int Date;
		public List<string> Authors;

		public Book(string title, int date)
		{
			Date = date;
			Title = title;
			Authors = new List<string>();
			if (String.IsNullOrEmpty(title))
            {
				throw new ArgumentNullException(); // i couldn't figure out the appropriate exception for both null or empty...
			}
		}

		public Book(string title)
		{
			Title = title;
			Authors = new List<string>();
			if (String.IsNullOrEmpty(title))
			{
				throw new ArgumentNullException(); // i couldn't figure out the appropriate exception for both null or empty...
			}
		}

		public string AddAuthor(string Author)
        {
			foreach(string authorInList in Authors)
            {
				if(authorInList.Equals(Author))
                {
					return "The Author is already in the list"; 
                }
            }
			Authors.Add(Author);
			return "The author has been successfuly added";
        }

	}
}

