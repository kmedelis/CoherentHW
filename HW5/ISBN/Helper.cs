using System;
using System.Text;
using System.Text.RegularExpressions;

namespace ISBN
{
    public static class Helper
    {
        public static string FormatForIsbn(this string ISBN)
        {
            StringBuilder toReturn = new StringBuilder();
            if (Regex.IsMatch(ISBN, "^[0-9]{3}-[0-9]{1}-[0-9]{2}-[0-9]{6}-[0-9]{1}$") || Regex.IsMatch(ISBN, "^[0-9]{13}$"))
            {
                for (int i = 0; i < ISBN.Length; i++)
                {
                    char letter = ISBN[i];
                    if (Char.IsNumber(letter))
                    {
                        toReturn.Append(letter);
                    }

                }
            }
            else
            {
                return null;
            }
            return toReturn.ToString();
        }
    }
}

