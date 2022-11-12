using System;

namespace LearnLiveCoding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 5;
            double d = 5.0;
            string s = "Fajar Arif Kurniawan ";

            int i2;
            double d2;
            string s2;

            i2 = int.Parse(Console.ReadLine());
            d2 = double.Parse(Console.ReadLine());
            s2 = Console.ReadLine();

            Console.WriteLine(i + i2);

            Console.WriteLine("{0:F1}", d + d2);

            Console.WriteLine("{0}{1}", s, s2);
        }


    }
}
