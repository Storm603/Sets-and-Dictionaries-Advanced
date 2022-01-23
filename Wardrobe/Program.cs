using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOfClothes = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> clothes = new Dictionary<string, Dictionary<string, int>>();

            FillingUpWardrobe(numOfClothes, clothes);


            SearchingForCloth(clothes);
        }

        public static void SearchingForCloth(Dictionary<string, Dictionary<string, int>> clothes)
        {
            string[] lookedForCloth = Console.ReadLine().Split();
            string lookedColor = lookedForCloth[0];
            string lookedCloth = lookedForCloth[1];

            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (cloth.Key == lookedCloth && color.Key == lookedColor)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                        continue;
                    }
                    Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                }
            }
        }

        public static Dictionary<string, Dictionary<string, int>> FillingUpWardrobe(int numOfClothes, Dictionary<string, Dictionary<string, int>> clothes)
        {
            for (int i = 0; i < numOfClothes; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ");
                string[] clothesInInput = input[1].Split(",");
                string color = input[0];

                if (!clothes.ContainsKey(color))
                {
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (string cloth in clothesInInput)
                {
                    if (!clothes[color].ContainsKey(cloth))
                    {
                        clothes[color].Add(cloth, 0);
                    }

                    clothes[color][cloth]++;
                }
            }

            return clothes;
        }
    }
}
