using System;

namespace ReverseWordEachSentence
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int strLen, i, j;
            string str;
            string reverse = "", temp = "";

            Console.Write("Enter string : ");
            str = Console.ReadLine();

            strLen = str.Length - 1;

            for (i = 0; i <= strLen; i++)
            {
                temp += str[i];

                if ((str[i] == ' ') || (i == strLen))
                {
                    for (j = temp.Length - 1; j >= 0; j--)
                    {
                        reverse += temp[j];
                        if ((j == 0) && (i != strLen))
                            reverse += " ";
                    }
                    temp = "";
                }
            }

            Console.WriteLine("\nReverse of " + str + " :" + reverse);
            Console.ReadKey();
        }
    }
}
