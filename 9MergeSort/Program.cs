using System;

namespace _9MergeSort
{
    internal class Program
    {
        public static void MergeSorting(int[] input, int left, int right)
        {
            Printing(input);
            if (left < right)
            {
                int middle = (left + right) / 2;

                MergeSorting(input, left, middle);
                MergeSorting(input, middle + 1, right);
                int[] leftArray = new int[middle - left + 1];
                int[] rightArray = new int[right - middle];

                Array.Copy(input, left, leftArray, 0, middle - left + 1);
                Array.Copy(input, middle + 1, rightArray, 0, right - middle);

                int i = 0;
                int j = 0;
                for (int k = left; k < right + 1; k++)
                {
                    if (i == leftArray.Length)
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                    else if (j == rightArray.Length)
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else if (leftArray[i] <= rightArray[j])
                    {
                        input[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        input[k] = rightArray[j];
                        j++;
                    }
                }
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
            int[] arr = { 5, 7, 3, 4, 1 };

            Console.WriteLine("Before Sorting");
            Printing(arr);
            Console.WriteLine("Sorting Process starts:");
            MergeSorting(arr, 0, arr.Length - 1);
            Console.WriteLine("Sorting Process ends:");
            Console.WriteLine("After Sorting");
            Printing(arr);
            Console.ReadKey();

        }
    }
}
