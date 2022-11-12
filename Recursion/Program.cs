using System;

namespace Recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var fact = factorial(n);
            Console.WriteLine("The factorial of {0} is : {1} ", n, fact);
            Console.WriteLine(factorial(n));
        }

        static int factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return factorial(n - 1)*n;
        }
    }
}
