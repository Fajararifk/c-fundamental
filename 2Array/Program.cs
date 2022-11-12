using System;

namespace _2Array
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var str = Console.ReadLine();
            var arr = str.Split(' ');

            Array.Reverse(arr);

            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
