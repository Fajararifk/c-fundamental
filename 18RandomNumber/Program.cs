using System;

namespace _18RandomNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();
            Console.WriteLine("Random Number between 0 to 1000 but just 10 numbers: ");

            for (int i = 0; i <= 9; i++)
            {
                Console.WriteLine(r.Next(1000));
            }
            Console.ReadLine();
        }
    }
}
