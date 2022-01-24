using System;
using System.Collections.Generic;
using System.Linq;

namespace T10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> sides = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();
            string[] split = null;
            while (input != "Lumpawaroo")
            {
                split = input.Split();

                bool isExist = false;
                if (input.Contains("|"))
                { 
                    split = input.Split(" | ");

                    string side = split[0];
                    string user = split[1];


                    if (!sides.ContainsKey(side))
                    {
                        sides.Add(side, new List<string>());
                    }

                    foreach (var side1 in sides)
                    {
                        foreach (string user1 in side1.Value)
                        {
                            if (user1 == user)
                            {
                                isExist = true;
                                break;
                            }
                        }
                    }

                    if (isExist == false)
                    {
                        sides[side].Add(user);
                    }
                }
                else if (input.Contains("->"))
                {
                    split = input.Split(" -> ");
                    string user = split[0];
                    string side = split[1];

                    foreach (var side1 in sides)
                    {
                        foreach (string user1 in side1.Value)
                        {
                            if (user1 == user)
                            {
                                isExist = true;
                                sides[side1.Key].Remove(user);
                                if (side1.Value.Count == 0)
                                {
                                    sides.Remove(side1.Key);
                                }
                                break;
                            }
                        }
                    }

                    if (isExist == true)
                    {
                        sides[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                    else
                    {
                        sides[side].Add(user);
                        Console.WriteLine($"{user} joins the {side} side!");
                    }
                }

                input = Console.ReadLine();
            }


            //sides = sides.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in sides.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var name in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {name}");
                }
            }
        }
    }
}
