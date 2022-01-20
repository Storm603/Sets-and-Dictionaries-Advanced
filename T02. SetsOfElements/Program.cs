using System;
using System.Collections.Generic;
using System.Linq;

namespace T02._SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lengths = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            FillingSets(setOne, lengths[0]);
            FillingSets(setTwo, lengths[1]);

            SetComparation(setOne, setTwo);
        }

        private static void SetComparation(HashSet<int> setOne, HashSet<int> setTwo)
        {
            foreach (int element in setOne)
            {
                if (setTwo.Contains(element))
                {
                    Console.Write(element + " ");
                }
            }

        }

        private static HashSet<int> FillingSets(HashSet<int> set, int length)
        {
            for (int i = 0; i < length; i++)
            {
                set.Add(int.Parse(Console.ReadLine()));
            }

            return set;
        }
    }
}
