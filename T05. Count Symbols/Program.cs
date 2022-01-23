using System;
using System.Collections.Generic;

namespace T05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();

            SortedDictionary<char, int> letterOccurance = new SortedDictionary<char, int>();

            foreach (char letter in input)
            {
                if (!letterOccurance.ContainsKey(letter))
                {
                    letterOccurance.Add(letter, 0);
                }

                letterOccurance[letter]++;
            }

            foreach (KeyValuePair<char, int> pair in letterOccurance)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
