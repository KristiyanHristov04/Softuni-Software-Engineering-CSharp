using System;
using System.Collections.Generic;

namespace _06._Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end")
                {
                    break;
                }
                string[] commands = input.Split(" : ");
                string course = commands[0];
                string user = commands[1];
                if (result.ContainsKey(course))
                {
                    result[course].Add(user);
                }
                else
                {
                    result.Add(course, new List<string> { user });
                }

            }
            foreach (var course in result)
            {
                Console.WriteLine(course.Key + ": " + course.Value.Count);
                for (int i = 0; i < course.Value.Count; i++)
                {
                    Console.WriteLine("-- " + course.Value[i]);
                }
            }
        }
    }
}
