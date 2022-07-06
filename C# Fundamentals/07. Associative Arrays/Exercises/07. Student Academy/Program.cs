using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Student_Academy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<double>> result = new Dictionary<string, List<double>>();
            int n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n * 2; i += 2)
            {
                string studentName = Console.ReadLine();
                double studentGrade = Convert.ToDouble(Console.ReadLine());

                if (!result.ContainsKey(studentName))
                {
                    result.Add(studentName, new List<double>() { studentGrade });
                }
                else
                {
                    result[studentName].Add(studentGrade);
                }
            }

            Dictionary<string, List<double>> goodGrades = new Dictionary<string, List<double>>();
            foreach (var student in result)
            {
                double sum = 0;
                double average = 0;
                for (int i = 0; i < student.Value.Count; i++)
                {
                    sum += student.Value[i];
                }
                average = sum / student.Value.Count;
                if (average >= 4.50)
                {
                    goodGrades.Add(student.Key, new List<double>() { average });
                }
            }

            foreach (var student in goodGrades)
            {
                Console.WriteLine($"{student.Key} -> {student.Value[0]:f2}");
            }
        }
    }
}
