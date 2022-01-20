using System;
using System.Collections.Generic;
using System.Linq;

namespace T03._PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {

            int lines = int.Parse(Console.ReadLine());

            HashSet<string> elements = new HashSet<string>();

            PrintingUniqueElements(lines, elements);

        }

        private static void PrintingUniqueElements(int lines, HashSet<string> elements)
        {
            for (int i = 0; i < lines; i++)
            {
                string[] input = Console.ReadLine().Split();

                foreach (string element in input)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ", elements.OrderBy(x => x)));
        }
    }
}
