using System;
using System.Collections.Generic;
using System.Linq;
namespace _09._SoftUni_Exam_Results
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> results = new SortedDictionary<string, int>();
            SortedDictionary<string, int> submissions = new SortedDictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }

                string[] tokens = input.Split('-');
                string name = tokens[0];
                string language = tokens[1];
                if (language == "banned")
                {
                    if (results.ContainsKey(name))
                    {
                        results.Remove(name);
                        if (!submissions.ContainsKey(language) && language != "banned")
                        {
                            submissions.Add(language, 0);
                            submissions[language]++;
                        }

                        continue;
                    }
                }
                int points = int.Parse(tokens[2]);
                if (!results.ContainsKey(name))
                {
                    results.Add(name, points);
                }
                else
                {
                    if (results[name] < points)
                    {
                        results[name] = points;
                    }
                }

                if (!submissions.ContainsKey(language))
                {
                    submissions.Add(language, 0);
                }
                submissions[language]++;

            }
            Console.WriteLine("Results:");

            foreach (var item in results.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{item.Key} | {item.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in submissions.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}
