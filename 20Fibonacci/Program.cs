using System;

namespace _20Fibonacci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n;
            int a = 0;
            int b = 1;
            Console.Write("Enter the limit : ");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(a);
                int temp = a;
                a = b;
                b = temp + b;
            }
            Console.ReadLine();
        }
    }
}
