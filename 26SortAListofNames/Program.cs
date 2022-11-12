using System;
using System.Collections.Generic;

namespace _26SortAListofNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>();
            names.Add("Odegaard");
            names.Add("Ramsdale");
            names.Add("Ben White");
            names.Add("Tomiyasu");
            names.Add("Saliba");

            Console.WriteLine("Array without sorting..");

            foreach (string s in names)
                Console.WriteLine(s);
            names.Sort();

            Console.WriteLine("\nArray after sorting..");
            foreach (string s in names)
                Console.WriteLine(s);

            Console.ReadLine();
        }
    }
}
