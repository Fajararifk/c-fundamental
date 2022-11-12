using System;

namespace _7InsertionSorting
{
    internal class Program
    {
        static void InsertionSort(int[] input)
        {
            for (int i = 0; i < input.Length-1; i++)
            {
                for (int j = i+1; j > 0; j--)
                {
                    if (input[j-1] > input[j])
                    {
                        int temp = input[j - 1];
                        input[j-1] = input[j];
                        input[j] = temp;
                    }
                }
                Printing(input);
            }
        }

        public static void Printing(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            int[] arr = { 5, 7, 3,4,1};

            Console.WriteLine("Before Sorting: ");
            Printing(arr);
            Console.WriteLine("Sorting Process Starts: ");
            InsertionSort(arr);
            Console.WriteLine("Sorting Process Ends: ");
            Console.WriteLine("After Sorting: ");
            Printing(arr);
            Console.ReadKey();
        }
    }
}
