using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace T08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> rankings = new Dictionary<string, string>();

            string input = Console.ReadLine();

            while (input != "end of contests")
            {
                string[] info = input.Split(":");

                string contest = info[0];
                string password = info[1];

                if (!rankings.ContainsKey(contest))
                {
                    rankings.Add(contest, password);
                }

                input = Console.ReadLine();
            }
            
            input = Console.ReadLine();



            Dictionary<string, Dictionary<string, int>> students = new Dictionary<string, Dictionary<string, int>>();

            while (input != "end of submissions")
            {
                string[] info = input.Split("=>");

                string contest = info[0];
                string password = info[1];
                string username = info[2];
                int points = int.Parse(info[3]);

                if (rankings.ContainsKey(contest))
                {
                    if (rankings[contest] == password)
                    {
                        if (!students.ContainsKey(username))
                        {
                            students.Add(username, new Dictionary<string, int>());
                        }

                        if (!students[username].ContainsKey(contest))
                        {
                            students[username].Add(contest, points);
                        }
                        else
                        {
                            if (points > students[username][contest])
                            {
                                students[username][contest] = points;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            students = students.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value.OrderByDescending(y => y.Value).ToDictionary(y => y.Key, y => y.Value));

            foreach (KeyValuePair<string, Dictionary<string, int>> pair in students)
            {
                Console.WriteLine(pair.Key);
                foreach (KeyValuePair<string, int> course in pair.Value)
                {
                    Console.WriteLine($"# {course.Key} -> {course.Value}");
                }
            }

        }
    }
}
