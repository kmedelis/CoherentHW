using System;


namespace Ternary
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter number one:");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter number two:");
            int b = int.Parse(Console.ReadLine());
            int c = b - a;

            

            for (int i = 0; i < c; i++)
            {
                DecimalToTernary converter = new DecimalToTernary(a);
                a++;
            }

        }
    }
}