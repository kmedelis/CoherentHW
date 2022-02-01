using System;
using System.Text;

namespace ISBN
{
	public static class Helper
	{
		public static string FormatForIsbn(this string ISBN)
        {
			StringBuilder toReturn = new StringBuilder();
			for (int i = 0; i < ISBN.Length; i++)
            {
				char letter = ISBN[i];
				if(Char.IsNumber(letter))
                {
					toReturn.Append(letter);
                }
				
            }
			return toReturn.ToString();
        }
	}
}

