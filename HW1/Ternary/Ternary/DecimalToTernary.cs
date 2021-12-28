using System;
using System.Text;
using System.Linq;
using System.Collections;
using System.Diagnostics;

namespace Ternary
{
    public class DecimalToTernary
    {
        public DecimalToTernary(int n)
        {

            Stack stack = new Stack();
            Queue que = new Queue();
            int length = 0;
            int count = 0;

         
            while (n != 0) // converts from base 10 to base 3
            {
                int temp = n % 3;
                stack.Push(temp);
                length++;
                n /= 3;
            }



            for (int i = 0; length > i; i++) // checks if there are exactly two 2's in ternary format
            {
                int temp = (int)stack.Pop();

                if (temp == 2)
                {
                    count++;
                }

                que.Enqueue(temp);
            }

            if (count == 2) // deques the number if it has two 2's in ternary
            {
                for (int i = 0; length > i; i++)
                {
                    Console.Write(que.Dequeue());
                }
                Console.WriteLine("");

            }
        }
    }
}
