using System;

namespace _19SquareRoot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            Console.WriteLine("Enter Your Number: ");
            n = Convert.ToInt32(Console.ReadLine());

            double square = Math.Sqrt(n);
            Console.Write("\n Square root of "+ n+" is "+ Convert.ToString(Math.Round(square,3)));
            Console.ReadLine();
        }
    }
}
