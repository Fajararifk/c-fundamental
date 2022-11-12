using System;

namespace _12SearchingBin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, num, item, first, last, middle;
            int[] array;
            Console.Write("Enter number of elements : ");
            num = Convert.ToInt32(Console.ReadLine());

            array = new int[num];

            Console.WriteLine("\nEnter " + num + " integers in sorted order : ");
            for (i = 0; i < num; i++)
                array[i] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the search value : ");
            item = Convert.ToInt32(Console.ReadLine());

            first = 0;
            last = num - 1;
            middle = (first + last) / 2;

            while (first <= last)
            {
                if (array[middle] < item)
                    first = middle + 1;

                else if (array[middle] == item)
                {
                    Console.WriteLine("\n" + item + " found at location " + (middle + 1) + ".");
                    break;
                }
                else
                {
                    last = middle - 1;
                }
                middle = (first + last) / 2;
            }
            if (first > last)
                Console.WriteLine("\n" + item + " is not found.\n");

            Console.ReadLine();
        }
    }
}
