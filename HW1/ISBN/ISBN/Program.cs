using System;

namespace ISBN
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("input 9 digit ISBN: ");
            string isbn = Console.ReadLine();
            int sum = 0;

            for (int i = 0; i != 9; i++)
                sum += (i + 1) * int.Parse(isbn[i].ToString());

            int remainder = sum % 11;

            if (remainder == 10)
                Console.WriteLine(isbn + 'X');
            else
                Console.WriteLine(isbn + (char)('0' + remainder));
        }
    }
}