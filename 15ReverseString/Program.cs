using System;

namespace _15ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String ori, reverse = "";
            Console.WriteLine("Enter a string to reverse input: ");
            ori = Console.ReadLine();
            int len = ori.Length;
            for (int i = len-1; i >=0; i--)
            {
                reverse = reverse + ori[i];
                ori = ori.ToLower();
                reverse = reverse.ToLower();
            }
            Console.WriteLine("\nReverse of " + ori + "is: "+ reverse);
            Console.ReadLine();
        }
    }
}
