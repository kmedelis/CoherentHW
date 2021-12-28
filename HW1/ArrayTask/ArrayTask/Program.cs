using System;


namespace Array
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Declare the size of the array: ");
            int arraySize = int.Parse(Console.ReadLine());

            int[] array = new int[arraySize];
            int max = 0;
            int indexMax = 0;
            int min = 0;
            int indexMin = 0;
            int indexTrack = 0;
            int sum = 0;

            for (int i = 0; i < array.Length; i++) //adds elements to the array
            {
                Console.WriteLine("");
                Console.WriteLine("Enter the number that will be in the array: ");
                int arrayElement = int.Parse(Console.ReadLine());
                array[i] = arrayElement;
            }

            min = array[0];

            Console.WriteLine("");

            foreach (int number in array)
            {
                if (number >= max) //selects rightmost max value
                {
                    max = number;
                    indexMax = indexTrack;
                }
                if (number < min) //selects leftmost min value
                {
                    min = number;
                    indexMin = indexTrack;
                }


                indexTrack++;
            }

            Console.WriteLine("lowest number is " + min + " at index: " + indexMin); //I left this for convenience
            Console.WriteLine("highest number is " + max + " at index: " + indexMax);


            if (indexMin>indexMax) // this reverses the indexMin if the higher number comes before the lower number so that the next function would work correctly.
            {
                int temp = indexMin;
                indexMin = indexMax;
                indexMax = temp;

            }

            for (int i = indexMin; i <= indexMax; i++) 
            {
                sum += array[i];
            }

            Console.WriteLine("");
            Console.WriteLine("The final sum is: " + sum);

        }
    }
}