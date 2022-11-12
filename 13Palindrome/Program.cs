using System;
using System.Linq;

namespace _13Palindrome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String ori, reverse = "";
            Console.WriteLine("Enter a string what you want: ");
            ori = Console.ReadLine();

            int len = ori.Length;

            for (int i = len-1; i >= 0; i--)
            {
                reverse = reverse + ori.ElementAt(i);
                
            }
            if (ori.Equals(reverse))
            {
                Console.WriteLine("Entered string is a palindrome");
            }
            else
            {
                Console.WriteLine("Entered string is not a palindrome");
            }
            Console.ReadLine();
        }
    }
}
