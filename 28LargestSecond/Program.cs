using System;

namespace _28LargestSecond
{
    internal class Program
    {
        public static void Print2Largest(int[] arr, int len_arr)
        {
            int i, first, second;
            if(len_arr < 2)
            {
                Console.WriteLine("Invalid input");
                return;
            }
            first = second = int.MinValue;
            for (i = 0; i < len_arr; i++)
            {
                if (arr[i] > first)
                {
                    second = first;
                    first = arr[i];
                }
                else if (arr[i]> second && arr[i] != first)
                {
                    second = arr[i];
                }
            }
            Console.Write("The second largest is " + second);
        }
        static void Main(string[] args)
        {
            int[] arr = { 10, 33, 3, 11, 22, 4 };
            int n = arr.Length;
            Print2Largest(arr, n);
        }
    }
}
