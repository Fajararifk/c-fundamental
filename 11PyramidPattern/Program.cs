﻿using System;

namespace _11PyramidPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of levels of pyramid : ");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nPyramid : ");

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k <= i; k++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
