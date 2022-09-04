using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Average_Student_Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();
                string name = input[0];
                decimal grade = Convert.ToDecimal(input[1]);
                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<decimal>());
                    students[name].Add(grade);
                }
            }

            foreach (var student in students)
            {
                string gradesString = string.Empty;
                for (int i = 0; i < student.Value.Count; i++)
                {
                    gradesString += $"{student.Value[i]:f2} ";
                }
                Console.WriteLine($"{student.Key} -> {gradesString}(avg: {student.Value.Average():f2})");
            }
        }
    }
}
