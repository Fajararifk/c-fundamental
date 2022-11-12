using System;

namespace _29MostFrequent
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[7] { 40, 50, 30, 40, 30, 30, 10 };
            int n = arr.Length;
            int count = 1, tempCount;
            int frequent = arr[0];
            int temp = 0;
            for(int i = 0; i < (n - 1); i++)
            {
                temp = arr[i];
                tempCount = 0;
                for(int j = 0; j < n; j++)
                {
                    if(temp == arr[j])
                    {
                        tempCount++;
                    }
                }
                if(tempCount > count)
                {
                    frequent = temp;
                    count = tempCount;
                }
            }
            Console.WriteLine("The most frequent number in this array is {0} has been repeated {1} times.", frequent, count);
            Console.ReadKey();

        }
    }
}
