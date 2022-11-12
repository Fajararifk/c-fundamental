using System;

namespace _23GreatesNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num, i, temp, max;
            Console.WriteLine("Enter the range :");
            num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter " + num + " number: ");
            max = Convert.ToInt32(Console.ReadLine());
            for (i = 1; i < num; i++)
            {
                temp = Convert.ToInt32((Console.ReadLine()));
                if (temp < max)
                {
                    continue;
                }
                else
                {
                    max = temp;
                }
            }
            Console.WriteLine("\nLargest Number is " + max);
            Console.ReadLine();
        }
    }
}
