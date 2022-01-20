using System;
using System.Collections.Generic;

namespace Sets_and_Dictionaries_Advanced_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {

            int totalNames = int.Parse(Console.ReadLine());
            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < totalNames; i++)
            {
                string name = Console.ReadLine();
                uniqueNames.Add(name);
            }

            Console.WriteLine(string.Join("\n", uniqueNames));
        }
    }
}
