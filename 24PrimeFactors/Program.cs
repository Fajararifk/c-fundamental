using System;

namespace _24PrimeFactors
{
    internal class Program
    {
        public bool prime(int a)
        {
            bool b = true;
            for (int i = 2; i <= (a / 2); i++)
            {
                if (a % i == 0)
                {
                    b = false;
                }
            }
            return b;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Program o = new Program();
            Console.Write("\nPrime Factors of " + a + " are : ");
            for (int i = 1; i <=(a/2); i++)
            {
                if (a % i == 0)
                {
                    bool b = o.prime(i);
                    if(b== true)
                    {
                        Console.Write(i + " ");
                    }
                }
            }
        }
    }
}
