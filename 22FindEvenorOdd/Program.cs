using System;

namespace _22FindEvenorOdd
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i;
            Console.WriteLine("Enter a number: ");
            i = int.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                Console.Write(i + " is an Even Number");
            }
            else
            {
                Console.Write(i + " is ad Odd Number");
            }
            Console.Read();
        }
    }
}
