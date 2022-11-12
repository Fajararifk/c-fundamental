using System;

namespace TriangleBin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i, j, k, rows;

            Console.Write("Enter the Number of Rows : ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nBinary Triangle \n");
            for (i = 1; i <= rows; i++)
            {
                for (k = rows - i; k >= 1; k--)
                {
                    Console.Write(" ");
                }

                if (i % 2 != 0)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (j % 2 == 0)
                        {
                            Console.Write("0 ");
                        }

                        else
                        {
                            Console.Write("1 ");
                        }
                    }
                }

                else if (i % 2 == 0)
                {
                    for (j = 1; j <= i; j++)
                    {
                        if (j % 2 == 0)
                        {
                            Console.Write("1 ");
                        }

                        else
                        {
                            Console.Write("0 ");
                        }
                    }
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
