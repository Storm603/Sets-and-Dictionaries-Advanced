using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace T09._SoftUni_Exam_Results
{
    class Program
    {
        static void Main(string[] args)
        {

            Dictionary<string, Dictionary<string, int>> studentCollection = new Dictionary<string, Dictionary<string, int>>();
            Dictionary<string, int> submissions = new Dictionary<string, int>();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] split = input.Split("-");

                string name = split[0];

                if (split[1] == "banned") // student ban
                {
                    studentCollection.Remove(name);
                    input = Console.ReadLine();
                    continue;
                }

                string language = split[1];
                int points = int.Parse(split[2]);

                if (!submissions.ContainsKey(language)) // submission counts in 2nd dict
                {
                    submissions.Add(language, 0);
                }
                submissions[language]++;

                if (!studentCollection.ContainsKey(name)) // checks if student exists in first dict
                {
                    studentCollection.Add(name, new Dictionary<string, int>());
                }

                if (!studentCollection[name].ContainsKey(language)) // checks if student has the language in 1st dict
                {
                    studentCollection[name].Add(language, 0);
                }

                if (studentCollection[name][language] < points) // checks if points are higher than current ones in 1st dict
                {
                    studentCollection[name][language] = points;
                }

                input = Console.ReadLine();
            }

            studentCollection = studentCollection.OrderByDescending(x => x.Value.Values.Max()).ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine("Results:");
            foreach (var name in studentCollection)
            {
                Console.WriteLine($"{name.Key} | {name.Value.Values.First()}");
            }

            submissions = submissions.OrderByDescending(x => x.Value).ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Submissions:");
            foreach (var langage in submissions)
            {
                Console.WriteLine($"{langage.Key} - {langage.Value}");
            }
        }
    }
}
