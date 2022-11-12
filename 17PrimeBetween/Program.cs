using System;

namespace _17PrimeBetween
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i,j,up_limit,low_limit, flag=1,counter=0;
            Console.WriteLine("Enter the lower limit of the range: ");
            low_limit = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter the upper limit of the range: ");
            up_limit = int.Parse(Console.ReadLine());

            Console.WriteLine("\nThe Prime Numbers between the Range" + low_limit + " - " + up_limit + "are \n");
            for (i = low_limit+1; i < up_limit; i++)
            {
                for (j = 2; j <= i / 2; j++)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 1&& i!= 1)
                {
                    Console.Write(i + " ");
                    counter++;
                }
                flag = 1;
            }
            Console.WriteLine("\n\n The Number of Prime Number between the range " + low_limit + " - " + up_limit + " : " + counter);
            Console.ReadLine();
        }
    }
}
