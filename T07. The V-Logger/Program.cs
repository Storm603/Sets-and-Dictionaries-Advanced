using System;
using System.Collections.Generic;
using System.Linq;

namespace T07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, List<string>> followers = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> followed = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while (input != "Statistics")
            {
                string[] action = input.Split();
                string vlogger = action[0];


                if (action[1] == "joined")
                {
                    if (!followers.ContainsKey(vlogger))
                    {
                        followers.Add(vlogger, new List<string>());
                        followed.Add(vlogger, new List<string>());
                    }
                }
                else if (action[1] == "followed")
                {
                    string followedVlogger = action[2];
                    if (vlogger == followedVlogger || followers[followedVlogger].Contains(vlogger))
                    {
                        input = Console.ReadLine();
                        continue;
                    }

                    if (!followed[vlogger].Contains(followedVlogger))
                    {
                        followed[vlogger].Add(followedVlogger);
                        followers[followedVlogger].Add(vlogger);
                    }
                }

                input = Console.ReadLine();
            }

            followers = followers.OrderByDescending(x => x.Value.Count).ToDictionary(x => x.Key, x => x.Value);

            foreach (KeyValuePair<string, List<string>> pair in followers)
            {
                Console.WriteLine(
                    );
            }
        }
    }
}
