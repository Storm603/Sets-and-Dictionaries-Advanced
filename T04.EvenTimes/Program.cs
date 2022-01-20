using System;
using System.Collections.Generic;

namespace T04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());

            Dictionary<int, int> evenNum = new Dictionary<int, int>();

            EvenNumberSeparator(lines, evenNum);
        }

        private static void EvenNumberSeparator(int lines, Dictionary<int, int> evenNum)
        {
            for (int i = 0; i < lines; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (!evenNum.ContainsKey(input))
                {
                    evenNum[input] = 1;
                }

                evenNum[input]++;
            }

            foreach (KeyValuePair<int, int> pair in evenNum)
            {
                if (pair.Value % 2 == 1)
                {
                    Console.WriteLine(pair.Key);
                }
            }
        }

    }
}
