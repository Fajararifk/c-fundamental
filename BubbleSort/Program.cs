using System;

namespace BubbleSort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 120, 23, 453, 123, 2446, 2324, 5, 77, 4646, 12 };
            int temp = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length-1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
            for (int k = 0; k < arr.Length; k++)
            {
                Console.Write(arr[k] + " ");

                Console.ReadKey();
            }
        }
    }
}
