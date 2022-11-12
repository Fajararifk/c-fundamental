using System;

namespace _27CheckAlphabetVowel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char alphabet;
            char c;

            Console.Write("Enter a Alphabet : ");
            alphabet = Convert.ToChar(Console.ReadLine());

            c = Char.ToUpper(alphabet);

            if (c.Equals('A') || c.Equals('E') || c.Equals('I') || c.Equals('O') ||
                c.Equals('U'))
            {
                Console.WriteLine("{0} is vowel", alphabet);
            }
            else
            {
                Console.WriteLine("{0} is not vowel", alphabet);
            }

            
            Console.Read();
        }
    }
}
